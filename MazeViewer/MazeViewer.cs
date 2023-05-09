// -----------------------------------------------------------------------
//  <copyright project="MazeDebugger" file="MazeViewer.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeDebugger;

using System.Drawing.Drawing2D;
using MazeGenerator;
using Timer = System.Windows.Forms.Timer;

public class MazeViewer : Control
{
    private static readonly Brush s_mazeCursorColor = Brushes.Blue;

    private static readonly Brush s_mazeEntranceColor = Brushes.Gold;

    private static readonly Brush s_mazeExitColor = Brushes.Red;

    private static readonly Brush s_mazeSolutionColor = Brushes.Green;

    private static readonly Color s_mazeWallColor = Color.Black;

    private readonly Dictionary<string, Brush> _cursorColor = new ();

    private readonly Timer _updateTimer = new ();

    private int _generationHistoryIndex;

    private Maze? _maze;

    private int _solutionIndex;

    public MazeViewer()
    {
        Resize += MazeViewer_Resize;
        _updateTimer.Interval = 100;
    }

    public Maze? Maze
    {
        get => _maze;

        set
        {
            _updateTimer.Stop();

            _updateTimer.Tick -= DrawMazeOnUpdateTimerTick;
            _updateTimer.Tick -= DrawSolutionOnUpdateTimerTick;

            _updateTimer.Tick += DrawMazeOnUpdateTimerTick;

            _updateTimer.Start();

            _maze = value;
        }
    }

    private Rectangle DestRect => new (Padding.Left, Padding.Top, Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom);

    private Rectangle SrcRect => new (0, 0, Maze?.Width * 2 + 1 ?? 0, Maze?.Height * 2 + 1 ?? 0);

    /// <inheritdoc />
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.Clear(s_mazeWallColor);

        if (Maze is null)
        {
            return;
        }

        GraphicsContainer containerState = e.Graphics.BeginContainer(DestRect, SrcRect, GraphicsUnit.Pixel);

        e.Graphics.FillRectangle(s_mazeEntranceColor, Maze.Entrance.X * 2, Maze.Entrance.Y * 2 + 1, 1, 1);
        e.Graphics.FillRectangle(s_mazeExitColor, Maze.Exit.X * 2 + 2, Maze.Exit.Y * 2 + 1, 1, 1);

        foreach (MazeGenerationAction generationAction in Maze.GenerationHistory.Take(_generationHistoryIndex).SelectMany(static c => c))
        {
            if (!_cursorColor.ContainsKey(generationAction.CursorId))
            {
                Random random = new (generationAction.CursorId.GetHashCode());
                _cursorColor.Add(generationAction.CursorId, new SolidBrush(Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256))));
            }

            PaintCorridor(e.Graphics, generationAction.Position.X, generationAction.Position.Y, generationAction.Direction, _cursorColor[generationAction.CursorId]);
        }

        if (Maze.Solution is not null && _generationHistoryIndex >= Maze.GenerationHistory.Count)
        {
            PaintWay(e.Graphics, Maze.Entrance, Maze.Solution.Take(_solutionIndex), s_mazeSolutionColor);
        }

        e.Graphics.EndContainer(containerState);
    }

    private static void PaintCorridor(Graphics g, int x, int y, EDirection direction, Brush brush)
    {
        if (direction.HasFlag(EDirection.North))
        {
            g.FillRectangle(brush, x * 2 + 1, y * 2 - 2 + 1, 1, 3);
        }

        if (direction.HasFlag(EDirection.East))
        {
            g.FillRectangle(brush, x * 2 + 1, y * 2 + 1, 3, 1);
        }

        if (direction.HasFlag(EDirection.South))
        {
            g.FillRectangle(brush, x * 2 + 1, y * 2 + 1, 1, 3);
        }

        if (direction.HasFlag(EDirection.West))
        {
            g.FillRectangle(brush, x * 2 - 2 + 1, y * 2 + 1, 3, 1);
        }
    }

    private static void PaintCursorPosition(Graphics g, int x, int y, EDirection direction)
    {
        (int cursorX, int cursorY) = direction switch
        {
            EDirection.East => (x * 2 + 3, y * 2 + 1),
            EDirection.North => (x * 2 + 1, y * 2 - 1),
            EDirection.South => (x * 2 + 1, y * 2 + 3),
            EDirection.West => (x * 2 - 1, y * 2 + 1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction)),
        };

        g.FillRectangle(s_mazeCursorColor, cursorX, cursorY, 1, 1);
    }

    private static void PaintWay(Graphics g, (int, int) startPosition, IEnumerable<EDirection> way, Brush color)
    {
        (int x, int y) = startPosition;

        foreach (EDirection direction in way)
        {
            PaintCorridor(g, x, y, direction, color);

            (x, y) = direction switch
            {
                EDirection.East => (x + 1, y),
                EDirection.North => (x, y - 1),
                EDirection.South => (x, y + 1),
                EDirection.West => (x - 1, y),
                _ => throw new NotSupportedException(),
            };
        }
    }

    private void DrawMazeOnUpdateTimerTick(object? sender, EventArgs e)
    {
        if (Maze?.GenerationHistory is null || _generationHistoryIndex >= Maze.GenerationHistory.Count)
        {
            _updateTimer.Tick -= DrawMazeOnUpdateTimerTick;
            _updateTimer.Tick += DrawSolutionOnUpdateTimerTick;
            return;
        }

        Graphics graphics = CreateGraphics();

        GraphicsContainer containerState = graphics.BeginContainer(DestRect, SrcRect, GraphicsUnit.Pixel);

        IEnumerable<MazeGenerationAction> pointsToPaint = Maze.GenerationHistory[_generationHistoryIndex];

        foreach (MazeGenerationAction generationAction in pointsToPaint)
        {
            PaintCorridor(graphics, generationAction.Position.X, generationAction.Position.Y, generationAction.Direction, GetCursorColor(generationAction.CursorId));

            if (_generationHistoryIndex < Maze.GenerationHistory.Count - 1)
            {
                PaintCursorPosition(graphics, generationAction.Position.X, generationAction.Position.Y, generationAction.Direction);
            }
        }

        graphics.EndContainer(containerState);

        _generationHistoryIndex++;
    }

    private void DrawSolutionOnUpdateTimerTick(object? sender, EventArgs e)
    {
        if (Maze?.Solution is null || _solutionIndex > Maze.Solution.Count())
        {
            _updateTimer.Stop();
            return;
        }

        Graphics graphics = CreateGraphics();

        GraphicsContainer containerState = graphics.BeginContainer(DestRect, SrcRect, GraphicsUnit.Pixel);

        IEnumerable<EDirection> corridorsToPaint = Maze.Solution.Take(_solutionIndex);

        PaintWay(graphics, Maze.Entrance, corridorsToPaint, s_mazeSolutionColor);

        graphics.EndContainer(containerState);

        _solutionIndex++;
    }

    private Brush GetCursorColor(string cursorId)
    {
        if (!_cursorColor.ContainsKey(cursorId))
        {
            Random random = new (cursorId.GetHashCode());
            _cursorColor.Add(cursorId, new SolidBrush(Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256))));
        }

        return _cursorColor[cursorId];
    }

    private void MazeViewer_Resize(object? sender, EventArgs e)
    {
        Invalidate();
    }
}
