// -----------------------------------------------------------------------
// <copyright file="MazeCellUpdatedEventArgs.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Types.Mazes
{
    using MazeGenerator.Types.Cursors;

    public record MazeCellUpdatedEventArgs(MazeCell MazeCell, int CursorId);
}