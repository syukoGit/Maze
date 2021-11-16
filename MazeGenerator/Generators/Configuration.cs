// -----------------------------------------------------------------------
// <copyright file="Configuration.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Generators
{
    using MazeGenerator.Types.Base;

    public record Configuration(Probability ProbabilityCursorToDivide, uint NbMaxRunningCursor);
}