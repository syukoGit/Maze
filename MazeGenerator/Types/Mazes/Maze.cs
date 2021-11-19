// -----------------------------------------------------------------------
// <copyright file="Maze.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Types.Mazes
{
    using MazeGenerator.Types.Base;
    using MazeGenerator.Types.Cursors;
    using System.Collections;
    using System.Collections.Generic;

    public class Maze : IEnumerable<MazeCell>
    {
        private readonly EDirection[,] maze;

        public Maze(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            this.maze = new EDirection[width, height];
        }

        public Coordinates Entry { get; init; } = (0, 0);

        public Coordinates Exit { get; init; } = (0, 1);

        public int Height { get; }

        public EDirection this[int x, int y] => this.maze[x, y];

        public int Width { get; }

        public delegate void MazeCellUpdatedHandler(object sender, MazeCellUpdatedEventArgs args);

        public event MazeCellUpdatedHandler MazeCellUpdated;

        public IEnumerator<MazeCell> GetEnumerator() => new MazeEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        internal void AddDirection(Coordinates coordinates, EDirection direction, Cursor cursor)
        {
            (int x, int y) = coordinates;
            if (this.maze[x, y].HasFlag(direction))
            {
                return;
            }

            this.maze[x, y] |= direction;
            this.MazeCellUpdated?.Invoke(this, new MazeCellUpdatedEventArgs(new MazeCell(direction, (x, y)), cursor.Id));
        }
    }
}