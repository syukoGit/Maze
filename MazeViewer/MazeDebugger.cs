// -----------------------------------------------------------------------
//  <copyright project="MazeDebugger" file="MazeDebugger.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeDebugger;

using MazeGenerator;
using MazeGenerator.Cursors;
using MazeGenerator.Generators;

public partial class MazeDebugger : Form
{
    private Task? _generateTask;

    private CancellationTokenSource _generateTaskCancellationTokenSource = new ();

    public MazeDebugger()
    {
        InitializeComponent();
    }

    private void GenerateButton_Click(object sender, EventArgs e)
    {
        if (_generateTask is not null)
        {
            _generateTaskCancellationTokenSource.Cancel();
            _generateTaskCancellationTokenSource.Dispose();
        }

        _generateTaskCancellationTokenSource = new CancellationTokenSource();

        _generateTask = GenerateMaze(_generateTaskCancellationTokenSource.Token);
    }

    private async Task GenerateMaze(CancellationToken cancellationToken)
    {
        var random = new Random();
        int width = (int) _widthBox.Value;
        int height = (int) _heightBox.Value;

        var maze = new RectangularMaze(width, height)
        {
            Entrance = (0, random.Next(height)),
            Exit = (width - 1, random.Next(height)),
        };

        IMazeGenerator generator = new DefaultMazeGenerator();

        await generator.GenerateAsync(maze, cancellationToken);

        _mazeViewer.Maze = maze;
        _mazeViewer.Invalidate();

        foreach (ICursor cursor in maze.Log.Cursors)
        {
            _cursorsTreeView.Nodes.Add(cursor.Id.ToString());
        }
    }
}
