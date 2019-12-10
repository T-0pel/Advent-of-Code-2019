using System;
using System.Collections.Generic;
using System.Numerics;

namespace Day3
{
    public class Point : IEquatable<Point>
    {
        public Vector2 Position { get; set; }
        public int StepCount { get; set; }

        public bool Equals(Point other)
        {
            return Position == other.Position;
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode();
        }
    }
}