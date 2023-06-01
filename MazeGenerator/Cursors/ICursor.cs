// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="ICursor.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Cursors;

using System;

public interface ICursor
{
    public Guid Id { get; }

    public ICursor? Parent { get; }
}
