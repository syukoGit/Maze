﻿// -----------------------------------------------------------------------
// <copyright file="MazeGeneratorBase.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Generators
{
    using MazeGenerator.Types;
    using MazeGenerator.Types.Cursors;
    using MazeGenerator.Types.Mazes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class MazeGeneratorBase : IMazeGenerator
    {
        private readonly List<Cursor> cursors = new();

        protected MazeGeneratorBase(int height, int width)
        {
            this.Height = height;
            this.Width = width;

            Cursor.ExitFound += this.Cursor_ExitFound;
            Cursor.NewCursor += this.Cursor_NewCursor;
            Cursor.StateChanged += this.Cursor_StateChanged;
        }

        public Configuration Configuration { get; init; } = new();

        public int Height { get; }

        public Maze Maze { get; protected set; }

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

        public IReadOnlyList<EDirection> WayToExit { get; private set; }

        public int Width { get; }

        public event IMazeGenerator.CursorStateChangedHandler CursorStateChanged;

        public abstract Task Generate(CancellationToken token);

        public abstract Maze InitMaze();

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

        private void Cursor_StateChanged(object sender, ECursorState state)
        {
            if (sender is Cursor cursor)
            {
                this.CursorStateChanged?.Invoke(cursor.Id, EventArgs.Empty);
            }
        }
    }
}