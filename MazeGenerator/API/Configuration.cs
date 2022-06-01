// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="Configuration.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.API
{
    using JetBrains.Annotations;
    using MazeGenerator.Types.Base;

    [PublicAPI]
    public class Configuration
    {
        public uint NbMaxRunningCursor { get; init; } = 10;

        public Probability ProbabilityCursorToSplit { get; init; } = 5;

        public uint WaitingTimeCursorMs { get; init; } = 50;
    }
}
