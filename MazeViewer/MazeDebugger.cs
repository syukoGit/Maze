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
    public MazeDebugger()
    {
        InitializeComponent();

        var random = new Random();
        const int width = 10;
        const int height = 10;

        var maze = new RectangularMaze(width, height)
        {
            Entrance = (0, random.Next(height)),
            Exit = (width - 1, random.Next(height)),
        };

        IMazeGenerator generator = new DefaultMazeGenerator();

        Task task = generator.Generate(maze);

        task.Wait();

        _mazeViewer.Maze = maze;
        _mazeViewer.Invalidate();
    }
}
