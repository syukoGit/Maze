﻿// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="Cursor.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Cursors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Extensions;

internal class Cursor : ICursor
{
    protected readonly Maze Maze;

    protected readonly Random Random = new ();

    private readonly Cursor? _parent;

    private readonly Stack<EDirection> _way = new ();

    private (int X, int Y) _position;

    protected Cursor(Maze maze, (int X, int Y) position)
    {
        Maze = maze;
        Position = position;
    }

    internal Cursor(Cursor parent, Maze maze, (int X, int Y) position)
        : this(maze, position)
    {
        Maze = maze;
        Position = position;
        _parent = parent;
    }

    public Guid Id { get; } = Guid.NewGuid();

    /// <inheritdoc />
    public ICursor? Parent => _parent;

    protected (int X, int Y) Position
    {
        get => _position;

        private set
        {
            if (value.X < 0 || value.X >= Maze.Width || value.Y < 0 || value.Y >= Maze.Height)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }

            _position = value;
        }
    }

    private IEnumerable<EDirection> EntireWay => _parent is null
                                                     ? _way
                                                     : _way.Concat(_parent.EntireWay);

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        do
        {
            if (Position == Maze.Exit)
            {
                Maze.Solution = new List<EDirection>(EntireWay.Reverse());

                GoBack();
            }
            else
            {
                await Action(cancellationToken);
            }
        }
        while (_way.Count > 0);
    }

    protected virtual async Task Action(CancellationToken cancellationToken)
    {
        await Task.Run(Move, cancellationToken);
    }

    protected EDirection GetAvailableDirections()
    {
        int x = Position.X;
        int y = Position.Y;

        var directions = EDirection.None;

        if (x + 1 < Maze.Width && Maze[x + 1, y] == EDirection.NotSet)
        {
            directions |= EDirection.East;
        }

        if (x - 1 >= 0 && Maze[x - 1, y] == EDirection.NotSet)
        {
            directions |= EDirection.West;
        }

        if (y + 1 < Maze.Height && Maze[x, y + 1] == EDirection.NotSet)
        {
            directions |= EDirection.South;
        }

        if (y - 1 >= 0 && Maze[x, y - 1] == EDirection.NotSet)
        {
            directions |= EDirection.North;
        }

        return directions;
    }

    private void GoBack()
    {
        if (_way.TryPop(out EDirection direction))
        {
            EDirection oppositeDirection = direction.GetOpposite();

            Position = oppositeDirection.GetNewPosition(Position);
        }
    }

    private void Move()
    {
        lock (Maze)
        {
            EDirection directions = GetAvailableDirections();

            if (directions == EDirection.None)
            {
                GoBack();
                return;
            }

            EDirection direction = directions.GetRandomDirection(Random);

            (int X, int Y) newPosition = direction.GetNewPosition(Position);

            Maze.AddCorridor(this, Position, direction);

            _way.Push(direction);

            Position = newPosition;
        }
    }
}
