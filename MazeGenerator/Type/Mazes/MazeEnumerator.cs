// -----------------------------------------------------------------------
// <copyright file="MazeEnumerator.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Type.Mazes
{
    using MazeGenerator.Type.Base;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class MazeEnumerator : IEnumerator<MazeCell>
    {
        private readonly Maze maze;

        private Coordinates currentCoordinates = (-1, 0);

        public MazeEnumerator(Maze maze)
        {
            this.maze = maze;

            this.Current = default;
        }

        public MazeCell Current { get; private set; }

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.currentCoordinates.X + 1 >= this.maze.Width)
            {
                if (this.currentCoordinates.Y + 1 >= this.maze.Height)
                {
                    return false;
                }
                else
                {
                    this.currentCoordinates = (0, this.currentCoordinates.Y + 1);
                }
            }
            else
            {
                this.currentCoordinates = (this.currentCoordinates.X + 1, this.currentCoordinates.Y);
            }

            this.Current = new MazeCell(this.maze[this.currentCoordinates.X, this.currentCoordinates.Y], this.currentCoordinates);

            return true;
        }

        public void Reset() => throw new NotImplementedException();
    }
}