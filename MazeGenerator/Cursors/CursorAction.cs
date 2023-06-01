// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="CursorAction.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Cursors;

public sealed record CursorAction((int X, int Y) Position, EDirection Direction);
