// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="ICursor.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.API.Cursors
{
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using MazeGenerator.Types.Base;

    [PublicAPI]
    public interface ICursor
    {
        public Coordinates Coordinates { get; }

        public int Id { get; }

        [CanBeNull]
        public ICursor Parent { get; }

        public IReadOnlyList<EDirection> Way { get; }
    }
}
