// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="DefaultMazeGenerator.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Generators;

using System.Threading.Tasks;
using Cursors;

public class DefaultMazeGenerator : IMazeGenerator
{
    /// <inheritdoc />
    public async Task Generate(Maze maze)
    {
        var cursor = new Cursor(maze, maze.Entrance);

        await cursor.RunAsync();
    }
}
