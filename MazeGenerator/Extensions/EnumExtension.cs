// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="EnumExtension.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumExtension
{
    public static IEnumerable<T> GetFlags<T>(this T e) where T : Enum
    {
        return Enum.GetValues(e.GetType()).Cast<Enum>().Where(e.HasFlag).Cast<T>();
    }
}
