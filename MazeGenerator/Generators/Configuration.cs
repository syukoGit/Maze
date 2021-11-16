// -----------------------------------------------------------------------
// <copyright file="Configuration.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Generators
{
    using MazeGenerator.Types.Base;

    public class Configuration
    {
        public uint NbMaxRunningCursor { get; init; } = 10;

        public Probability ProbabilityCursorToSplit { get; init; } = 5;

        public uint WaitingTimeCursorMs { get; init; } = 50;
    }
}