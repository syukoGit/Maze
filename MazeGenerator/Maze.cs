// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="Maze.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator;

using System;
using System.Collections.Generic;
using Cursors;
using Extensions;
using MazeLogs;

public abstract class Maze
{
    private readonly EDirection[,] _maze;

    protected Maze(int width, int height)
    {
        Width = width;
        Height = height;
        _maze = new EDirection[width, height];

        Log = new MazeLog(this);
    }

    public required (int X, int Y) Entrance { get; init; }

    public required (int X, int Y) Exit { get; init; }

    public int Height { get; }

    public EDirection this[int x, int y] => _maze[x, y];

    public MazeLog Log { get; }

    public IEnumerable<EDirection>? Solution { get; internal set; }

    public int Width { get; }

    public event EventHandler<MazeUpdatedEventArgs>? MazeUpdated;

    internal void AddCorridor(ICursor cursor, (int X, int Y) coordinates, EDirection direction)
    {
        _maze[coordinates.X, coordinates.Y] |= direction;

        (int x, int y) = direction.GetNewPosition(coordinates);
        _maze[x, y] |= direction.GetOpposite();

        MazeUpdated?.Invoke(this, new MazeUpdatedEventArgs
        {
            Coordinates = coordinates,
            Direction = direction,
            UpdatedBy = cursor,
        });
    }
}
