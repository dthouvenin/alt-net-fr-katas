using System.Collections.Generic;
using System.Linq;
using Mazes.Core;

namespace EtudiantSolver
{
    public class EtudiantSolver : IMazeSolver
    {
        private readonly List<Position> casesDejaVisité = new List<Position>();
        private Position currentPosition;
        // O gauche, 1 haut, 2 droite, 3 bas
        private int direction;
        private int hasMoved;
        private IMaze maze;
        private IMouse mouse;

        public void Init(IMaze maze, IMouse mouse)
        {
            this.maze = maze;
            this.mouse = mouse;
            this.currentPosition = new Position(0, 0);
            this.casesDejaVisité.Add(this.currentPosition);
        }

        public void YourTurn()
        {
            if (this.maze.CanIMove())
            {
                var frontPosition = GetFrontPosition();
                var exist =
                    this.casesDejaVisité.FirstOrDefault(c => c.X == frontPosition.X && c.Y == frontPosition.Y);
                if (exist == null || this.hasMoved > 3)
                {
                    this.currentPosition = GetFrontPosition();
                    this.mouse.Move();
                    if (exist == null)
                        this.casesDejaVisité.Add(this.currentPosition);
                    this.hasMoved = 0;
                }
                else
                {
                    this.direction = (this.direction + 1)%4;
                    this.mouse.TurnRight();
                    this.hasMoved++;
                }
            }
            else
            {
                this.direction = (this.direction + 1)%4;
                this.mouse.TurnRight();
                this.hasMoved++;
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