// -----------------------------------------------------------------------
// <copyright file="MazeCell.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Type.Mazes
{
    using MazeGenerator.Type.Base;

    public record MazeCell(EDirection Directions, Coordinates Coordinates);
}