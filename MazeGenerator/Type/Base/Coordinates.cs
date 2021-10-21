// -----------------------------------------------------------------------
// <copyright file="Coordinates.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Type.Base
{
    using System;

    public class Coordinates
    {
        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public void Deconstruct(out int x, out int y)
        {
            x = this.X;
            y = this.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinates(var x, var y) && this.X == x && this.Y == y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.X, this.Y);
        }

        public static bool operator ==(Coordinates c1, Coordinates c2)
        {
            return c1 is not null && c1.Equals(c2);
        }

        public static implicit operator Coordinates((int X, int Y) coordinates)
        {
            (int x, int y) = coordinates;
            return new Coordinates(x, y);
        }

        public static bool operator !=(Coordinates c1, Coordinates c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }
    }
}