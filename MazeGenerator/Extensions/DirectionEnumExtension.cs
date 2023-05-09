// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="DirectionEnumExtension.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;

public static class DirectionEnumExtension
{
    public static int Count(this EDirection directions)
    {
        return directions.GetFlags().Where(static c => c != EDirection.None && c != EDirection.NotSet).Count();
    }

    public static EDirection GetOpposite(this EDirection direction)
    {
        return direction switch
        {
            EDirection.North => EDirection.South,
            EDirection.East => EDirection.West,
            EDirection.South => EDirection.North,
            EDirection.West => EDirection.East,
            _ => EDirection.None,
        };
    }

    public static EDirection GetRandomDirection(this EDirection directions, Random random)
    {
        List<EDirection> flags = directions.GetFlags().Where(static c => c != EDirection.None && c != EDirection.NotSet).ToList();

        int randomDirection = random.Next(0, flags.Count);

        return flags[randomDirection];
    }
}
