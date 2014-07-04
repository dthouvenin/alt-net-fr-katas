using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazes.Core;

namespace OurIncredibleMazeSolver
{
    public class OurIncredibleMazeSolver : IMazeSolver
    {
        private MazeNode _currentNode;
        private IMaze _maze;
        private IMouse _mouse;
        private Directions _facing = Directions.Right;
        private Stack<Directions> _movesStack = new Stack<Directions>();

        void IMazeSolver.Init(IMaze maze, IMouse mouse)
        {
            this._maze = maze;
            this._mouse = mouse;
        }

        void IMazeSolver.YouLoose()
        {
        }

        void IMazeSolver.YouWin()
        {
        }

        void IMazeSolver.YourTurn()
        {

        }

        private void FaceRight() { 
            switch (this._facing) {
                case Directions.Right:
                    break;
                case Directions.Left:
                    this._mouse.TurnRight();
                    this._mouse.TurnRight();
                    this._facing = Directions.Right;
                    break;
                case Directions.Up:
                    this._mouse.TurnRight();
                    this._facing = Directions.Right;
                    break;
                case Directions.Down:
                    this._mouse.TurnLeft();
                    this._facing = Directions.Right;
                    break;
            }
        }

        private void FaceLeft()
        {
            switch (this._facing)
            {
                case Directions.Right:
                    this._mouse.TurnRight();
                    this._mouse.TurnRight();
                    this._facing = Directions.Left;
                    break;
                case Directions.Left:                    
                    break;
                case Directions.Up:
                    this._mouse.TurnLeft();
                    this._facing = Directions.Left;
                    break;
                case Directions.Down:
                    this._mouse.TurnRight();
                    this._facing = Directions.Left;
                    break;
            }
        }
        private void FaceUp()
        {
            switch (this._facing)
            {
                case Directions.Right:
                    this._mouse.TurnLeft();
                    this._facing = Directions.Up;
                    break;
                case Directions.Left:
                    this._mouse.TurnRight();
                    this._facing = Directions.Up;
                    break;
                case Directions.Up:
                    break;
                case Directions.Down:
                    this._mouse.TurnRight();
                    this._mouse.TurnRight();
                    this._facing = Directions.Up;
                    break;
            }
        }
        private void FaceDown()
        {
            switch (this._facing)
            {
                case Directions.Right:
                    this._mouse.TurnRight();
                    this._facing = Directions.Down;
                    break;
                case Directions.Left:
                    this._mouse.TurnLeft();
                    this._facing = Directions.Down;
                    break;
                case Directions.Up:
                    this._mouse.TurnRight();
                    this._mouse.TurnRight();
                    this._facing = Directions.Down;
                    break;
                case Directions.Down:                    
                    break;
            }
        }
    }

    internal enum Directions { 
        Left=0,
        Right=1,
        Up=2,
        Down=3
    }


    internal class MazeNode
    {
        public MazeNode _rightNode;
        public MazeNode _leftNode;
        public MazeNode _upNode;
        public MazeNode _downNode;

        public bool IsInit { get; private set; }
        public bool Visited { get; set; }

    }
}
