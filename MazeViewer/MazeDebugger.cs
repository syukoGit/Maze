// -----------------------------------------------------------------------
//  <copyright project="MazeDebugger" file="MazeDebugger.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeDebugger;

using MazeGenerator;
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

        _generateTaskCancellationTokenSource = new ();

        _generateTask = GenerateMaze(_generateTaskCancellationTokenSource.Token);
    }

    private async Task GenerateMaze(CancellationToken cancellationToken)
    {
        var random = new Random();
        const int width = 10;
        const int height = 10;

        var maze = new RectangularMaze(width, height)
        {
            Entrance = (0, random.Next(height)),
            Exit = (width - 1, random.Next(height)),
        };

        IMazeGenerator generator = new DefaultMazeGenerator();

        await generator.GenerateAsync(maze, cancellationToken);

        _mazeViewer.Maze = maze;
        _mazeViewer.Invalidate();
    }
}
