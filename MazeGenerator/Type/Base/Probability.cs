// -----------------------------------------------------------------------
// <copyright file="Probability.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Type.Base
{
    using System;

    public struct Probability
    {
        private readonly int value;

        private Probability(int value)
        {
            this.value = value >= 0 && value <= 100
                ? value
                : throw new ArgumentOutOfRangeException(nameof(value), value, "The value must be between 0 and 100");
        }

        public static implicit operator Probability(int value) => new(value);

        public static implicit operator int(Probability probability) => probability.value;
    }
}