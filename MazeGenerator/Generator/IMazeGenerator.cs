// -----------------------------------------------------------------------
// <copyright file="IMazeGenerator.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Generator
{
    using MazeGenerator.Type;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMazeGenerator
    {
        public Configuration Configuration { get; }

        public int Height { get; }

        public Maze Maze { get; }

        public List<EDirection> WayToExit { get; }

        public int Width { get; }

        public void Cursor_ExitFound(object sender, List<EDirection> wayToExit);

        public Task Generate(CancellationToken token);

        public Maze InitMaze();
    }
}