// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="SplittableCursor.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Cursors;

using System.Threading;
using System.Threading.Tasks;
using Extensions;

internal class SplittableCursor : Cursor
{
    /// <inheritdoc />
    public SplittableCursor(Maze maze, (int x, int Y) position)
        : base(maze, position)
    {
    }

    /// <inheritdoc />
    private SplittableCursor(Cursor parent, Maze maze, (int x, int Y) position)
        : base(parent, maze, position)
    {
    }

    /// <inheritdoc />
    protected override async Task Action(CancellationToken cancellationToken)
    {
        if (GetAvailableDirections().Count() > 1 && Random.Next(100) < 5)
        {
            var child1 = new SplittableCursor(this, Maze, Position);
            var child2 = new SplittableCursor(this, Maze, Position);

            Task t1 = child1.RunAsync(cancellationToken);
            Task t2 = child2.RunAsync(cancellationToken);

            await Task.WhenAll(t1, t2);
        }
        else
        {
            Move();
        }
    }
}
