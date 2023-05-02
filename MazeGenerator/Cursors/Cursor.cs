// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="Cursor.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Cursors;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Extensions;

internal class Cursor
{
    private readonly Maze _maze;

    private readonly Stack<EDirection> _way = new ();

    private (int X, int Y) _position;

    public Cursor(Maze maze, (int X, int Y) position)
    {
        _maze = maze;
        Position = position;
    }

    public CursorHistory ActionHistory { get; } = new ();

    public string Id { get; } = Guid.NewGuid().ToString();

    private (int X, int Y) Position
    {
        get => _position;

        set
        {
            if (value.X < 0 || value.X >= _maze.Width || value.Y < 0 || value.Y >= _maze.Height)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }

            _position = value;
        }
    }

    public Task Run()
    {
        do
        {
            if (Position == _maze.Exit)
            {
                var solution = new List<EDirection>(_way);
                solution.Reverse();
                _maze.Solution = solution;

                GoBack();
            }
            else
            {
                Move();
            }
        }
        while (_way.Count > 0);

        _maze.GenerationHistory.AddCursorHistory(this);

        return Task.CompletedTask;
    }

    private static (int X, int Y) GetNewPosition((int X, int Y) position, EDirection direction)
    {
        return direction switch
        {
            EDirection.North => (position.X, position.Y - 1),
            EDirection.East => (position.X + 1, position.Y),
            EDirection.South => (position.X, position.Y + 1),
            EDirection.West => (position.X - 1, position.Y),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
        };
    }

    private EDirection GetAvailableDirections()
    {
        int x = Position.X;
        int y = Position.Y;

        var directions = EDirection.None;

        if (x + 1 < _maze.Width && _maze[x + 1, y] == EDirection.NotSet)
        {
            directions |= EDirection.East;
        }

        if (x - 1 >= 0 && _maze[x - 1, y] == EDirection.NotSet)
        {
            directions |= EDirection.West;
        }

        if (y + 1 < _maze.Height && _maze[x, y + 1] == EDirection.NotSet)
        {
            directions |= EDirection.South;
        }

        if (y - 1 >= 0 && _maze[x, y - 1] == EDirection.NotSet)
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

            ActionHistory.Add(Position, oppositeDirection);
            Position = GetNewPosition(Position, oppositeDirection);
        }
    }

    private void Move()
    {
        EDirection directions = GetAvailableDirections();

        if (directions == EDirection.None)
        {
            GoBack();
            return;
        }

        EDirection direction = directions.GetRandomDirection();

        (int X, int Y) newPosition = GetNewPosition(Position, direction);

        _maze[Position.X, Position.Y] |= direction;
        _maze[newPosition.X, newPosition.Y] |= direction.GetOpposite();

        _way.Push(direction);
        ActionHistory.Add(Position, direction);

        Position = newPosition;
    }
}
