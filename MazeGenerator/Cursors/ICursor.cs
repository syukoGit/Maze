// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="ICursor.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Cursors;

public interface ICursor
{
    public string Id { get; }

    public ICursor? Parent { get; }
}
