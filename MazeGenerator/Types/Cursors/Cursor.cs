// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="Cursor.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Types.Cursors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using MazeGenerator.API;
    using MazeGenerator.API.Cursors;
    using MazeGenerator.API.Generators;
    using MazeGenerator.Types.Base;
    using MazeGenerator.Types.Mazes;

    internal sealed class Cursor : ICursor
    {
        private readonly List<Task> cursorList = new ();

        private readonly Stack<EDirection> cursorWay = new ();

        private readonly TaskFactory factory;

        private readonly IMazeGenerator generator;

        private readonly Maze maze;

        private readonly Random rand;

        public Cursor(TaskFactory factory, IMazeGenerator generator, Maze maze, Coordinates coordinates,
                      [CanBeNull] ICursor parent = null)
        {
            this.factory = factory;
            this.generator = generator;
            this.maze = maze;
            this.Coordinates = coordinates;
            this.Parent = parent;
            this.Id = new Random().Next(10000);

            this.rand = new Random(this.Id);

            Cursor.NewCursor?.Invoke(this, EventArgs.Empty);
#if DEBUG
            Console.Out.WriteLine($"[Cursor {this.Id}] New cursor created");
#endif
        }

        /// <inheritdoc />
        public Coordinates Coordinates { get; private set; }

        public int Id { get; }

        public ICursor Parent { get; }

        public ECursorState State { get; private set; } = ECursorState.Running;

        [NotNull]
        public IReadOnlyList<EDirection> Way
        {
            get
            {
                var output = new List<EDirection>();

                if (this.Parent != null)
                {
                    output.AddRange(this.Parent.Way);
                }

                output.AddRange(this.cursorWay.Reverse());

                return output;
            }
        }

        public static event EventHandler<IReadOnlyList<EDirection>> ExitFound;

        public static event EventHandler NewCursor;

        public void Start()
        {
            do
            {
                this.Action();
            }
            while (this.cursorWay.Any());

            this.State = ECursorState.Ended;
#if DEBUG
            Console.Out.WriteLine($"[Cursor {this.Id}] End of cursor");
#endif
        }

        private void Action()
        {
            EDirection directions = this.GetAvailableDirections();

            if (directions == EDirection.None)
            {
                this.StepBack();
            }
            else
            {
                if (directions.GetValues().Count() > 1
                    && this.rand.Next(100) + 1 <= this.generator.Configuration.ProbabilityCursorToSplit
                    && this.generator.NbRunningCursors < this.generator.Configuration.NbMaxRunningCursor)
                {
                    this.Split();
                    return;
                }

                this.Move(directions);

                if (this.IsTheExitFound())
                {
                    Cursor.ExitFound?.Invoke(this, this.Way);
                    this.StepBack();
                }

                Thread.Sleep((int) this.generator.Configuration.WaitingTimeCursorMs);
            }
        }

        private EDirection GetAvailableDirections()
        {
            var output = EDirection.None;

            (int x, int y) = this.Coordinates;

            if (y + 1 < this.maze.Height && this.maze[x, y + 1] == EDirection.None)
            {
                output |= EDirection.Down;
            }

            if (x - 1 >= 0 && this.maze[x - 1, y] == EDirection.None)
            {
                output |= EDirection.Left;
            }

            if (x + 1 < this.maze.Width && this.maze[x + 1, y] == EDirection.None)
            {
                output |= EDirection.Right;
            }

            if (y - 1 >= 0 && this.maze[x, y - 1] == EDirection.None)
            {
                output |= EDirection.Top;
            }

            return output;
        }

        private bool IsTheExitFound()
        {
            return this.Coordinates == this.maze.Exit;
        }

        private void Move(EDirection availableDirections)
        {
            EDirection[] directions = availableDirections.GetValues().ToArray();

            EDirection nextDirection = directions.ToArray()[this.rand.Next(directions.Length)];

            (int nextX, int nextY) = nextDirection switch
            {
                EDirection.Down => (this.Coordinates.X, this.Coordinates.Y + 1),
                EDirection.Left => (this.Coordinates.X - 1, this.Coordinates.Y),
                EDirection.Right => (this.Coordinates.X + 1, this.Coordinates.Y),
                EDirection.Top => (this.Coordinates.X, this.Coordinates.Y - 1),
                _ => this.Coordinates,
            };

            lock (this.maze)
            {
                if (this.maze[nextX, nextY] == EDirection.None)
                {
                    this.maze.AddDirection(this.Coordinates, nextDirection, this);
                    this.maze.AddDirection((nextX, nextY), nextDirection.GetOppositeDirection(), this);
                }
                else
                {
                    return;
                }
            }

            this.cursorWay.Push(nextDirection);
            this.Coordinates = (nextX, nextY);
        }

        private void Split()
        {
            this.cursorList.Clear();

            var c1 = new Cursor(this.factory, this.generator, this.maze, this.Coordinates, this);

            var c2 = new Cursor(this.factory, this.generator, this.maze, this.Coordinates, this);

            Task t1 = this.factory.StartNew(() => c1.Start(),
                                            TaskCreationOptions.AttachedToParent
                                            | TaskCreationOptions.RunContinuationsAsynchronously);

            this.cursorList.Add(t1);

            Task t2 = this.factory.StartNew(() => c2.Start(),
                                            TaskCreationOptions.AttachedToParent
                                            | TaskCreationOptions.RunContinuationsAsynchronously);

            this.cursorList.Add(t2);
#if DEBUG
            Console.Out.WriteLine($"[Cursor {this.Id}] Waiting {this.cursorList.Count} tasks ({c1.Id} & {c2.Id})");
#endif
            this.State = ECursorState.Waiting;
            Task.WaitAll(this.cursorList.ToArray());
            this.State = ECursorState.Running;
#if DEBUG
            Console.Out.WriteLine($"[Cursor {this.Id}] Continues on its way");
#endif
        }

        private void StepBack()
        {
            if (this.cursorWay.Count == 0)
            {
                return;
            }

            this.Coordinates = this.cursorWay.Pop() switch
            {
                EDirection.Down => (this.Coordinates.X, this.Coordinates.Y - 1),
                EDirection.Left => (this.Coordinates.X + 1, this.Coordinates.Y),
                EDirection.Right => (this.Coordinates.X - 1, this.Coordinates.Y),
                EDirection.Top => (this.Coordinates.X, this.Coordinates.Y + 1),
                _ => this.Coordinates,
            };
        }
    }
}
