// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="GenerationStep.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.MazeLogs;

using Cursors;

public record GenerationStep((int X, int Y) Coordinates, EDirection Direction, ICursor UpdatedBy);
