// -----------------------------------------------------------------------
// <copyright file="DefaultMaze.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MazeGenerator.Type;
    using MazeGenerator.Type.Base;

    public class DefaultMaze : IMazeGenerator
    {
        private readonly Random rand = new(Environment.ProcessId);

        public DefaultMaze(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public Configuration Configuration { get; init; }

        public int Height { get; }

        public Maze Maze { get; private set; }

        public List<EDirection> WayToExit { get; private set; }

        public int Width { get; }

        public void Cursor_ExitFound(object sender, List<EDirection> wayToExit)
        {
            Console.Out.WriteLine($"[Maze] Exit found by {((Cursor)sender).Id}");

            this.WayToExit = wayToExit;
        }

        /// <inheritdoc />
        public async Task Generate(CancellationToken token)
        {
            var factory = new TaskFactory(token, TaskCreationOptions.PreferFairness, TaskContinuationOptions.PreferFairness, TaskScheduler.Default);

            await factory.StartNew(() =>
                         {
                             var cursor = new Cursor(factory, this, this.Maze, this.Maze.Entry);
                             cursor.ExitFound += this.Cursor_ExitFound;

                             cursor.Start();
                         }, token)
                         .ContinueWith(_ => Console.Out.WriteLine("Maze generated"), token);
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
    }
}