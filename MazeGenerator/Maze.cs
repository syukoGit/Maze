// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="Maze.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator;

using System.Collections.Generic;

public abstract class Maze
{
    private readonly EDirection[,] _maze;

    protected Maze(int width, int height)
    {
        Width = width;
        Height = height;
        _maze = new EDirection[width, height];
    }

    public required (int X, int Y) Entrance { get; init; }

    public required (int X, int Y) Exit { get; init; }

    public MazeGenerationHistory GenerationHistory { get; } = new ();

    public int Height { get; }

    public EDirection this[int x, int y]
    {
        get => _maze[x, y];

        internal set => _maze[x, y] = value;
    }

    public IEnumerable<EDirection>? Solution { get; internal set; }

    public int Width { get; }
}
