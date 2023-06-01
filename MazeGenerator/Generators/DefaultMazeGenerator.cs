// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="DefaultMazeGenerator.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Generators;

using System.Threading;
using System.Threading.Tasks;
using Cursors;

public class DefaultMazeGenerator : IMazeGenerator
{
    /// <inheritdoc />
    public async Task GenerateAsync(Maze maze, CancellationToken cancellationToken)
    {
        var cursor = new SplittableCursor(maze, maze.Entrance);

        await cursor.RunAsync(cancellationToken);
    }
}
