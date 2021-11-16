// -----------------------------------------------------------------------
// <copyright file="MazeCell.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Types.Mazes
{
    using MazeGenerator.Types.Base;

    public record MazeCell(EDirection Directions, Coordinates Coordinates);
}