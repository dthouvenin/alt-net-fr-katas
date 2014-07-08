using System.Collections.Generic;
using System.Linq;

namespace EtudiantSolver
{
    public class Position
    {
        private static List<Position> AlreadyBuildPositions = new List<Position>();

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="T:System.Object" />.
        /// </summary>
        public Position(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
            IsVisited = false;

            AlreadyBuildPositions.Add(this);
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        private Direction Direction { get; set; }
        public bool IsVisited { private get; set; }

        public RelativePosition WestPosition { get; set; }
        public RelativePosition NorthPosition { get; set; }
        public RelativePosition EastPosition { get; set; }
        public RelativePosition SouthPosition { get; set; }

        public Position GetPosition(int x, int y, Direction direction)
        {
            Position position = AlreadyBuildPositions.FirstOrDefault(p => p.IsEqual(x, y, direction)) ??
                                new Position(x, y, direction);

            switch (direction)
            {
                case Direction.North:
                    position.SouthPosition = new RelativePosition(this);
                    break;
                case Direction.East:
                    position.WestPosition = new RelativePosition(this);
                    break;
                case Direction.South:
                    position.NorthPosition = new RelativePosition(this);
                    break;
                case Direction.West:
                    position.EastPosition = new RelativePosition(this);
                    break;
            }

            return position;
        }

        private bool IsPathClear(Position fromPosition)
        {
            return IsVisited &&
                   GetIsPathClear(WestPosition, fromPosition) &&
                   GetIsPathClear(NorthPosition, fromPosition) &&
                   GetIsPathClear(EastPosition, fromPosition) &&
                   GetIsPathClear(SouthPosition, fromPosition);
        }

        private bool GetIsVisited(RelativePosition position)
        {
            return position != null && (position.IsWall || position.Position.IsVisited);
        }

        private bool GetIsPathClear(RelativePosition position, Position fromPosition)
        {
            return (position != null &&
                    (position.IsWall || fromPosition == position.Position ||
                     position.Position.IsPathClear(this)));
        }

        private bool IsEqual(int x, int y, Direction direction)
        {
            return X == x && Y == y && Direction == direction;
        }

        public int GetBestDirectionToGo(Direction direction, Direction incommingDirection)
        {
            // Value : 
            // 0 = Noeud déjà exploré
            // 1 = Case déjà exploré
            // 2 = Case non exploré
            var bestDirections = new Dictionary<Direction, int>
            {
                {Direction.West, 0},
                {Direction.North, 0},
                {Direction.East, 0},
                {Direction.South, 0}
            };

            if (!GetIsVisited(WestPosition))
            {
                bestDirections[Direction.West] = 2;
            }
            else if (!GetIsPathClear(WestPosition, this))
            {
                bestDirections[Direction.West] = 1;
            }

            if (!GetIsVisited(NorthPosition))
            {
                bestDirections[Direction.North] = 2;
            }
            else if (!GetIsPathClear(NorthPosition, this))
            {
                bestDirections[Direction.North] = 1;
            }

            if (!GetIsVisited(EastPosition))
            {
                bestDirections[Direction.East] = 2;
            }
            else if (!GetIsPathClear(EastPosition, this))
            {
                bestDirections[Direction.East] = 1;
            }

            if (!GetIsVisited(SouthPosition))
            {
                bestDirections[Direction.South] = 2;
            }
            else if (!GetIsPathClear(SouthPosition, this))
            {
                bestDirections[Direction.South] = 1;
            }

            int bestDirection = bestDirections.Where(d => d.Value > 0 && ((int) d.Key + 2)%4 != (int) incommingDirection)
                .Select(d => (int?) d.Key)
                .Max(d => d) ?? ((int) incommingDirection + 2)%4;

            return bestDirection - (int) direction;
        }

        public static void ClearCache()
        {
            AlreadyBuildPositions = new List<Position>();
        }
    }
}