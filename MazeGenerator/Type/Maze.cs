// -----------------------------------------------------------------------
// <copyright file="Maze.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Type
{
    using MazeGenerator.Type.Base;
    using MazeGenerator.Type.MazeObject;
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

        public EDirection this[int x, int y]
        {
            get => this.maze[x, y];

            set
            {
                if (this.maze[x, y] == value)
                {
                    return;
                }

                this.maze[x, y] = value;
                this.MazeCellUpdated?.Invoke(this, new MazeCellUpdatedEventArgs(new MazeCell(value, (x, y))));
            }
        }

        public int Width { get; }

        public delegate void MazeCellUpdatedHandler(object sender, MazeCellUpdatedEventArgs args);

        public event MazeCellUpdatedHandler MazeCellUpdated;

        public IEnumerator<MazeCell> GetEnumerator() => new MazeEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}