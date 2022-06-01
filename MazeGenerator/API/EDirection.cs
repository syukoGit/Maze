// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="EDirection.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using JetBrains.Annotations;

    [PublicAPI]
    [Flags]
    public enum EDirection
    {
        None = 0,

        Down = 1,

        Left = 2,

        Right = 4,

        Top = 8,
    }

    internal static class Extension
    {
        public static EDirection GetOppositeDirection(this EDirection direction)
        {
            return direction switch
            {
                EDirection.Down => EDirection.Top,
                EDirection.Left => EDirection.Right,
                EDirection.Right => EDirection.Left,
                EDirection.Top => EDirection.Down,
                _ => EDirection.None,
            };
        }

        [NotNull]
        public static IEnumerable<EDirection> GetValues(this EDirection directions)
        {
            return Enum.GetValues(typeof(EDirection))
                       .Cast<EDirection>()
                       .Where(direction => directions.HasFlag(direction) && direction != EDirection.None);
        }
    }
}
