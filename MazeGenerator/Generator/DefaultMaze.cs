// -----------------------------------------------------------------------
// <copyright file="DefaultMaze.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Generator
{
    using MazeGenerator.Type.Base;
    using MazeGenerator.Type.Cursors;
    using MazeGenerator.Type.Mazes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class DefaultMaze : IMazeGenerator
    {
        private readonly List<Cursor> cursors = new();

        private readonly Random rand = new(Environment.ProcessId);

        public DefaultMaze(int height, int width)
        {
            this.Height = height;
            this.Width = width;

            Cursor.ExitFound += this.Cursor_ExitFound;
            Cursor.NewCursor += this.Cursor_NewCursor;
        }

        public Configuration Configuration { get; init; }

        public int Height { get; }

        public Maze Maze { get; private set; }

        public int NbEndedCursors
        {
            get
            {
                lock (this.cursors)
                {
                    return this.cursors.Count(c => c.State == ECursorState.Ended);
                }
            }
        }

        public int NbRunningCursors
        {
            get
            {
                lock (this.cursors)
                {
                    return this.cursors.Count(c => c.State == ECursorState.Running);
                }
            }
        }

        public int NbTotalCursors
        {
            get
            {
                lock (this.cursors)
                {
                    return this.cursors.Count;
                }
            }
        }

        public int NbWaitingCursors
        {
            get
            {
                lock (this.cursors)
                {
                    return this.cursors.Count(c => c.State == ECursorState.Waiting);
                }
            }
        }

        public List<EDirection> WayToExit { get; private set; }

        public int Width { get; }

        /// <inheritdoc />
        public async Task Generate(CancellationToken token)
        {
            var factory = new TaskFactory(token, TaskCreationOptions.PreferFairness, TaskContinuationOptions.PreferFairness, TaskScheduler.Default);

            await factory.StartNew(() =>
                         {
                             var cursor = new Cursor(factory, this, this.Maze, this.Maze.Entry);

                             cursor.Start();
                         }, token)
#if DEBUG
                         .ContinueWith(_ =>
                         {
                             Console.Out.WriteLine("Maze generated");
                             Console.Out.WriteLine($"Number of cursors used : {this.NbTotalCursors}");
                         }, token)
#endif
                ;
        }

        public Maze InitMaze()
        {
            this.Maze = new Maze(this.Width, this.Height)
            {
                Entry = new Coordinates(0, this.rand.Next(this.Height)),
                Exit = new Coordinates(this.Width - 1, this.rand.Next(this.Height)),
            };

            return this.Maze;
        }

        private void Cursor_ExitFound(object sender, List<EDirection> wayToExit)
        {
#if DEBUG
            Console.Out.WriteLine($"[Maze] Exit found by {((Cursor)sender).Id}");
#endif
            this.WayToExit = wayToExit;
        }

        private void Cursor_NewCursor(object sender, EventArgs e)
        {
            lock (this.cursors)
            {
                this.cursors.Add((Cursor)sender);
            }
        }
    }
}