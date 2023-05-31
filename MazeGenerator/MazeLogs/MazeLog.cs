// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="MazeLog.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.MazeLogs;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cursors;

public class MazeLog : IReadOnlyList<GenerationStep>
{
    private readonly List<GenerationStep> _generationSteps = new ();

    public MazeLog(Maze maze)
    {
        maze.MazeUpdated += Maze_MazeUpdated;
    }

    /// <inheritdoc />
    public int Count => _generationSteps.Count;

    public IEnumerable<ICursor> Cursors => _generationSteps.Select(static c => c.UpdatedBy).Distinct();

    /// <inheritdoc />
    public GenerationStep this[int index] => _generationSteps[index];

    /// <inheritdoc />
    public IEnumerator<GenerationStep> GetEnumerator()
    {
        return _generationSteps.GetEnumerator();
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void Maze_MazeUpdated(object? sender, MazeUpdatedEventArgs args)
    {
        _generationSteps.Add(new GenerationStep(args.Coordinates, args.Direction, args.UpdatedBy));
    }
}
