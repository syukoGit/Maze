// -----------------------------------------------------------------------
// <copyright file="Configuration.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Generator
{
    using MazeGenerator.Type.Base;

    public record Configuration(Probability ProbabilityCursorToDivide, uint NbMaxRunningCursor);
}