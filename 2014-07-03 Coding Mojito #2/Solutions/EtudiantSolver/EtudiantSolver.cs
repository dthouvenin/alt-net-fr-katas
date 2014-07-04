using System.Collections.Generic;
using System.Linq;
using Mazes.Core;

namespace EtudiantSolver
{
    public class EtudiantSolver : IMazeSolver
    {
        private List<Position> alreadyVisitedList;
        private Position currentPosition;
        // O gauche, 1 haut, 2 droite, 3 bas
        private int direction;
        private int turnWithoutMove;
        private IMaze maze;
        private IMouse mouse;

        public void Init(IMaze maze, IMouse mouse)
        {
            this.maze = maze;
            this.mouse = mouse;
            this.currentPosition = new Position(0, 0);
            this.alreadyVisitedList = new List<Position> {this.currentPosition};
        }

        public void YourTurn()
        {
            if (this.maze.CanIMove())
            {
                var frontPosition = GetFrontPosition();
                var exist = this.alreadyVisitedList.FirstOrDefault(c => c.IsEqual(frontPosition));
                if (exist == null || this.turnWithoutMove > 3)
                {
                    this.currentPosition = frontPosition;
                    this.mouse.Move();
                    if (exist == null)
                        this.alreadyVisitedList.Add(this.currentPosition);
                    this.turnWithoutMove = 0;
                }
                else
                {
                    this.direction = (this.direction + 1)%4;
                    this.mouse.TurnRight();
                    this.turnWithoutMove++;
                }
            }
            else
            {
                this.direction = (this.direction + 1)%4;
                this.mouse.TurnRight();
                this.turnWithoutMove++;
            }
        }

        public void YouWin()
        {
        }

        public void YouLoose()
        {
        }

        private Position GetFrontPosition()
        {
            return this.direction == 0
                ? new Position(this.currentPosition.X - 1, this.currentPosition.Y)
                : (this.direction == 1
                    ? new Position(this.currentPosition.X, this.currentPosition.Y + 1)
                    : (this.direction == 2
                        ? new Position(this.currentPosition.X + 1, this.currentPosition.Y)
                        : new Position(this.currentPosition.X, this.currentPosition.Y - 1)));
        }
    }
}