﻿// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="IMazeGenerator.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Generators;

using System.Threading.Tasks;

public interface IMazeGenerator
{
    Task Generate(Maze maze);
}
