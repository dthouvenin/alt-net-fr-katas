namespace Altnet.Katas.CodingMojito
{
    public class Direction
    {
        private readonly CardinalPoints direction;

        private enum CardinalPoints
        {
            North,
            East,
            South,
            West
        }

        private Direction(CardinalPoints direction)
        {
            this.direction = direction;
        }

        public static Direction North = new Direction(CardinalPoints.North);
        public static Direction South = new Direction(CardinalPoints.South);
        public static Direction East = new Direction(CardinalPoints.East);
        public static Direction West = new Direction(CardinalPoints.West);

        public Direction TurnRight()
        {
            if (this == North)
            {
                return East;
            }
            if (this == East)
            {
                return South;
            }
            if (this == South)
            {
                return West;
            }
            return North;
        }

        public Direction GetOpposite()
        {
            if (this == North)
            {
                return South;
            }
            if (this == East)
            {
                return West;
            }
            if (this == South)
            {
                return North;
            }
            return East;
        }

        public override string ToString()
        {
            return direction.ToString();
        }
    }
}