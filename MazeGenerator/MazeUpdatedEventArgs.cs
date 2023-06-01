// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="MazeUpdatedEventArgs.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator;

using System;
using Cursors;

public class MazeUpdatedEventArgs : EventArgs
{
    public required (int X, int Y) Coordinates { get; init; }

    public required EDirection Direction { get; init; }

    public required ICursor UpdatedBy { get; init; }
}
