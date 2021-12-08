// -----------------------------------------------------------------------
// <copyright file="MazeDisplay.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace DebugMazeApplication.Controls
{
    using MazeGenerator.Types.Base;
    using MazeGenerator.Types.Mazes;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Windows.Forms;

    public partial class MazeDisplay : UserControl
    {
        private readonly Dictionary<int, Color> cursorColor = new();

        private readonly Dictionary<Coordinates, Color> mazeCellColor = new();

        private Maze maze;

        public MazeDisplay()
        {
            this.InitializeComponent();
        }

        private RectangleF DestRect { get; set; } = RectangleF.Empty;

        public bool DifferentColorForEachCursor { get; set; }

        public Maze Maze
        {
            get => this.maze;

            set
            {
                if (this.maze != null)
                {
                    this.maze.MazeCellUpdated -= this.Maze_MazeCellUpdated;
                }

                this.maze = value;

                if (this.maze == null)
                {
                    return;
                }

                this.maze.MazeCellUpdated += this.Maze_MazeCellUpdated;
                this.DestRect = new RectangleF(0.0F, 0.0F, (this.Maze.Width * 2) + 1, (this.Maze.Height * 2) + 1);

                this.Invalidate();
            }
        }

        private RectangleF SrcRect { get; set; } = RectangleF.Empty;

        public void Clear()
        {
            this.cursorColor.Clear();
            this.mazeCellColor.Clear();
        }

        private void DrawMazeCell(Graphics graphics, MazeCell mazeCell)
        {
            Color color = this.mazeCellColor.ContainsKey(mazeCell.Coordinates)
                              ? this.mazeCellColor[mazeCell.Coordinates]
                              : Color.White;

            (EDirection directions, (int x, int y)) = mazeCell;

            graphics.FillRectangle(new SolidBrush(color), (x * 2) + 1, (y * 2) + 1, 1, 1);

            if (directions.HasFlag(EDirection.Down))
            {
                graphics.FillRectangle(new SolidBrush(color), (x * 2) + 1, (y * 2) + 2, 1, 1);
            }

            if (directions.HasFlag(EDirection.Left))
            {
                graphics.FillRectangle(new SolidBrush(color), x * 2, (y * 2) + 1, 1, 1);
            }

            if (directions.HasFlag(EDirection.Right))
            {
                graphics.FillRectangle(new SolidBrush(color), (x * 2) + 2, (y * 2) + 1, 1, 1);
            }

            if (directions.HasFlag(EDirection.Top))
            {
                graphics.FillRectangle(new SolidBrush(color), (x * 2) + 1, y * 2, 1, 1);
            }
        }

        private void Maze_MazeCellUpdated(object sender, MazeCellUpdatedEventArgs args)
        {
            (MazeCell mazeCell, int cursorId) = args;
            if (this.DifferentColorForEachCursor)
            {
                if (!this.cursorColor.ContainsKey(cursorId))
                {
                    var r = new Random(cursorId);
                    this.cursorColor[cursorId] = Color.FromArgb(r.Next(40, 256), r.Next(40, 256), r.Next(40, 256));
                }
            }
            else
            {
                this.cursorColor[cursorId] = Color.White;
            }

            this.mazeCellColor[mazeCell.Coordinates] = this.cursorColor[cursorId];

            Graphics graphic = this.CreateGraphics();

            GraphicsContainer containerState = graphic.BeginContainer(this.SrcRect, this.DestRect, GraphicsUnit.Pixel);

            this.DrawMazeCell(graphic, mazeCell);

            graphic.EndContainer(containerState);
        }

        private void MazeDisplay_Paint(object sender, PaintEventArgs e)
        {
            if (this.InvokeRequired)
            {
                new PaintEventHandler(this.MazeDisplay_Paint).Invoke(sender, e);
                return;
            }

            GraphicsContainer containerState = e.Graphics.BeginContainer(this.SrcRect, this.DestRect, GraphicsUnit.Pixel);

            e.Graphics.Clear(this.BackColor);

            if (this.Maze != null)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), this.Maze.Entry.X * 2, (this.Maze.Entry.Y * 2) + 1, 1, 1);
                e.Graphics.FillRectangle(new SolidBrush(Color.White), (this.Maze.Exit.X * 2) + 2, (this.Maze.Exit.Y * 2) + 1, 1, 1);

                lock (this.Maze)
                {
                    var mazeCells = this.Maze.Where(c => c.Directions != EDirection.None).ToList();
                    mazeCells.ForEach(c => this.DrawMazeCell(e.Graphics, c));
                }
            }
            else
            {
                e.Graphics.DrawString("No maze", new Font(FontFamily.GenericSerif, 12), new SolidBrush(Color.White), 0, 0);
            }

            e.Graphics.EndContainer(containerState);
        }

        private void MazeDisplay_Resize(object sender, EventArgs e)
        {
            this.SrcRect = new RectangleF(this.Padding.Left, this.Padding.Top, this.Width - this.Padding.Left - this.Padding.Right, this.Height - this.Padding.Top - this.Padding.Bottom);
            this.Invalidate();
        }
    }
}