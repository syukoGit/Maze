// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="MazeCellUpdatedEventArgs.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Types.Mazes
{
    public record MazeCellUpdatedEventArgs(MazeCell MazeCell, int CursorId);
}
