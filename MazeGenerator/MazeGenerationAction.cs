// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="MazeGenerationAction.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator;

public record MazeGenerationAction((int X, int Y) Position, EDirection Direction, string CursorId);
