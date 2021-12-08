// -----------------------------------------------------------------------
// <copyright file="IMazeGenerator.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Generators
{
    using MazeGenerator.Types;
    using MazeGenerator.Types.Mazes;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMazeGenerator
    {
        public Configuration Configuration { get; init; }

        public int Height { get; }

        public Maze Maze { get; }

        public int NbEndedCursors { get; }

        public int NbRunningCursors { get; }

        public int NbTotalCursors { get; }

        public int NbWaitingCursors { get; }

        public IReadOnlyList<EDirection> WayToExit { get; }

        public int Width { get; }

        public delegate void CursorStateChangedHandler(int cursorId, EventArgs e);

        public event CursorStateChangedHandler CursorStateChanged;

        public Task Generate(CancellationToken token);

        public Maze InitMaze();
    }
}