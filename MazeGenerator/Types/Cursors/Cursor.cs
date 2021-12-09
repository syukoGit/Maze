// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="Cursor.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Types.Cursors
{
    using MazeGenerator.Generators;
    using MazeGenerator.Types.Base;
    using MazeGenerator.Types.Mazes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class Cursor
    {
        private readonly List<Task> cursorList = new ();

        private readonly Stack<EDirection> cursorWay = new ();

        private readonly TaskFactory factory;

        private readonly IMazeGenerator generator;

        private readonly Maze maze;

        private readonly Random rand;

        private Coordinates coordinates;

        private ECursorState state = ECursorState.Running;

        public Cursor(TaskFactory factory, IMazeGenerator generator, Maze maze, Coordinates coordinates)
            : this(factory, generator, maze, coordinates, null)
        {
        }

        private Cursor(TaskFactory factory, IMazeGenerator generator, Maze maze, Coordinates coordinates, Cursor parent)
        {
            this.factory = factory;
            this.generator = generator;
            this.maze = maze;
            this.coordinates = coordinates;
            this.Id = new Random().Next(100000);
            this.Parent = parent;

            this.rand = new Random(this.Id);

            Cursor.NewCursor?.Invoke(this, EventArgs.Empty);
#if DEBUG
            Console.Out.WriteLine($"[Cursor {this.Id}] New cursor created");
#endif
        }

        public int Id { get; }

        public Cursor Parent { get; }

        public ECursorState State
        {
            get => this.state;

            private set
            {
                this.state = value;

                Cursor.StateChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private List<EDirection> Way
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

        public delegate void ExitFoundHandler(object sender, List<EDirection> wayToExit);

        public static event ExitFoundHandler ExitFound;

        public static event EventHandler NewCursor;

        public static event EventHandler StateChanged;

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
                if (directions.GetValues().Count() > 1 && this.rand.Next(100) + 1 <= this.generator.Configuration.ProbabilityCursorToSplit && this.generator.NbRunningCursors < this.generator.Configuration.NbMaxRunningCursor)
                {
                    this.SplitCursor();
                    return;
                }

                this.Move(directions);

                if (this.IsTheExitFound())
                {
                    Cursor.ExitFound?.Invoke(this, this.Way);
                    this.StepBack();
                }

                Thread.Sleep((int)this.generator.Configuration.WaitingTimeCursorMs);
            }
        }

        private EDirection GetAvailableDirections()
        {
            EDirection output = EDirection.None;

            (int x, int y) = this.coordinates;

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

        private bool IsTheExitFound() => this.coordinates == this.maze.Exit;

        private void Move(EDirection availableDirections)
        {
            EDirection[] directions = availableDirections.GetValues().ToArray();

            EDirection nextDirection = directions.ToArray()[this.rand.Next(directions.Length)];

            (int nextX, int nextY) = nextDirection switch
            {
                EDirection.Down => (this.coordinates.X, this.coordinates.Y + 1),
                EDirection.Left => (this.coordinates.X - 1, this.coordinates.Y),
                EDirection.Right => (this.coordinates.X + 1, this.coordinates.Y),
                EDirection.Top => (this.coordinates.X, this.coordinates.Y - 1),
                _ => this.coordinates,
            };

            lock (this.maze)
            {
                if (this.maze[nextX, nextY] == EDirection.None)
                {
                    this.maze.AddDirection(this.coordinates, nextDirection, this);
                    this.maze.AddDirection((nextX, nextY), nextDirection.GetOppositeDirection(), this);
                }
                else
                {
                    return;
                }
            }

            this.cursorWay.Push(nextDirection);
            this.coordinates = (nextX, nextY);
        }

        private void SplitCursor()
        {
            this.cursorList.Clear();

            var c1 = new Cursor(this.factory, this.generator, this.maze, this.coordinates, this);

            var c2 = new Cursor(this.factory, this.generator, this.maze, this.coordinates, this);

            Task t1 = this.factory.StartNew(() => c1.Start(), TaskCreationOptions.AttachedToParent | TaskCreationOptions.RunContinuationsAsynchronously);

            this.cursorList.Add(t1);

            Task t2 = this.factory.StartNew(() => c2.Start(), TaskCreationOptions.AttachedToParent | TaskCreationOptions.RunContinuationsAsynchronously);

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

            this.coordinates = this.cursorWay.Pop() switch
            {
                EDirection.Down => (this.coordinates.X, this.coordinates.Y - 1),
                EDirection.Left => (this.coordinates.X + 1, this.coordinates.Y),
                EDirection.Right => (this.coordinates.X - 1, this.coordinates.Y),
                EDirection.Top => (this.coordinates.X, this.coordinates.Y + 1),
                _ => this.coordinates,
            };
        }
    }
}