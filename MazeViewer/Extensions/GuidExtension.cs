// -----------------------------------------------------------------------
//  <copyright project="MazeDebugger" file="GuidExtension.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeDebugger.Extensions;

public static class GuidExtension
{
    public static Color ToColor(this Guid guid)
    {
        var random = new Random(guid.GetHashCode());
        return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
    }
}
