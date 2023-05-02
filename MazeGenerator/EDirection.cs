// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="EDirection.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator;

using System;

[Flags]
public enum EDirection
{
    NotSet = 0,

    None = 1,

    North = 2,

    East = 4,

    South = 8,

    West = 16,
}
