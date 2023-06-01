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
        return directions.GetFlags().Count(static c => c != EDirection.None && c != EDirection.NotSet);
    }

    public static (int X, int Y) GetNewPosition(this EDirection direction, (int, int) position)
    {
        (int x, int y) = position;

        if (direction.HasFlag(EDirection.North))
        {
            y--;
        }

        if (direction.HasFlag(EDirection.East))
        {
            x++;
        }

        if (direction.HasFlag(EDirection.South))
        {
            y++;
        }

        if (direction.HasFlag(EDirection.West))
        {
            x--;
        }

        return (x, y);
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
