// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="DefaultMazeGenerator.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Generators
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using MazeGenerator.Types.Base;
    using MazeGenerator.Types.Cursors;
    using MazeGenerator.Types.Mazes;

    [PublicAPI]
    public class DefaultMazeGenerator : MazeGeneratorBase
    {
        private readonly Random rand = new (Environment.ProcessId);

        public DefaultMazeGenerator(int height, int width)
            : base(height, width)
        {
        }

        /// <inheritdoc />
        public override async Task Generate(CancellationToken token)
        {
            var factory = new TaskFactory(token, TaskCreationOptions.PreferFairness,
                                          TaskContinuationOptions.PreferFairness, TaskScheduler.Default);

            await factory.StartNew(() =>
                         {
                             var cursor = new SplitCursor(factory, this, this.Maze, this.Maze.Entry);

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

        [NotNull]
        public override Maze InitMaze()
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
