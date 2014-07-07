using System;

namespace Altnet.Katas.CodingMojito
{
    public struct Coordinates
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;

        private static Coordinates zero = new Coordinates(0,0);
        public static Coordinates Zero { get { return zero; } }

        public Coordinates Move(Direction direction)
        {
            if (direction == Direction.East)
            {
                return new Coordinates(X + 1, Y);
            }
            if (direction == Direction.South)
            {
                return new Coordinates(X, Y + 1);
            }
            if (direction == Direction.West)
            {
                return new Coordinates(X - 1, Y);
            }
            return new Coordinates(X, Y - 1);
        }

        public bool IsEastOf(Coordinates other)
        {
            return other.X < X;
        }

        public bool IsWestOf(Coordinates other)
        {
            return other.X > X;
        }

        public bool IsNorthOf(Coordinates other)
        {
            return other.Y < Y;
        }

        public bool IsSouthOf(Coordinates other)
        {
            return other.Y > Y;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }
    }
}