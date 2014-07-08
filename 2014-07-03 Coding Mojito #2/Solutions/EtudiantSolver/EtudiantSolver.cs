using System;
using Mazes.Core;

namespace EtudiantSolver
{
    public class EtudiantSolver : IMazeSolver
    {
        private Position currentPosition;
        private Direction direction;
        private Direction incommingDirection;
        private IMaze maze;
        private IMouse mouse;

        public void Init(IMaze maze, IMouse mouse)
        {
            this.maze = maze;
            this.mouse = mouse;
            this.currentPosition = new Position(0, 0, Direction.West) {IsVisited = true};
            this.direction = this.incommingDirection = Direction.West;
            Position.ClearCache();
        }

        public void YourTurn()
        {
            RelativePosition frontPosition = GetFrontPosition();

            if (this.maze.CanIMove())
            {
                MoveToBestDirection(frontPosition);
            }
            else
            {
                frontPosition.IsWall = true;
                MoveToBestDirection(frontPosition);
            }
        }

        public void YouWin()
        {
        }

        public void YouLoose()
        {
        }

        private void MoveToBestDirection(RelativePosition frontPosition)
        {
            int moves = this.currentPosition.GetBestDirectionToGo(this.direction, this.incommingDirection);

            if (moves > 0)
            {
                for (int i = 0; i < moves; i++)
                {
                    this.direction = (Direction) (((int) this.direction + 1)%4);
                    this.mouse.TurnRight();
                }
            }
            else if (moves < 0)
            {
                for (int i = 0; i < Math.Abs(moves); i++)
                {
                    this.direction = (Direction) (((int) this.direction - 1)%4);
                    this.mouse.TurnLeft();
                }
            }
            else
            {
                this.currentPosition = frontPosition.Position;
                this.currentPosition.IsVisited = true;
                this.incommingDirection = this.direction;
                this.mouse.Move();
            }
        }

        private RelativePosition GetFrontPosition()
        {
            RelativePosition relativePosition = null;

            switch (this.direction)
            {
                case Direction.North:
                    relativePosition = this.currentPosition.NorthPosition ??
                                       (this.currentPosition.NorthPosition =
                                           new RelativePosition(this.currentPosition.GetPosition(this.currentPosition.X,
                                               this.currentPosition.Y + 1,
                                               this.direction)));
                    break;
                case Direction.East:
                    relativePosition = this.currentPosition.EastPosition ??
                                       (this.currentPosition.EastPosition =
                                           new RelativePosition(
                                               this.currentPosition.GetPosition(this.currentPosition.X + 1,
                                                   this.currentPosition.Y,
                                                   this.direction)));
                    break;
                case Direction.South:
                    relativePosition = this.currentPosition.SouthPosition ??
                                       (this.currentPosition.SouthPosition =
                                           new RelativePosition(this.currentPosition.GetPosition(this.currentPosition.X,
                                               this.currentPosition.Y - 1,
                                               this.direction)));
                    break;
                case Direction.West:
                    relativePosition = this.currentPosition.WestPosition ??
                                       (this.currentPosition.WestPosition =
                                           new RelativePosition(
                                               this.currentPosition.GetPosition(this.currentPosition.X - 1,
                                                   this.currentPosition.Y,
                                                   this.direction)));
                    break;
            }

            return relativePosition;
        }
    }
}