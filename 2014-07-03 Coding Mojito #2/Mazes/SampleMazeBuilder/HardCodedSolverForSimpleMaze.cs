using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mazes.Core;

namespace SampleMazeBuilder
{
    public class HardCodedSolverForSimpleMaze: IMazeSolver
    {
        private IMaze Maze;
        private IMouse Mouse;
        private int turn = 0;

        public void Init(IMaze maze, IMouse mouse)
        {
            Mouse = mouse;
            Maze = maze;
            turn = 0;
        }

        public void YourTurn()
        {
            var step = ++turn % 4;
            if(step % 2 == 0)
                Mouse.Move();
            else
                if(step % 3 == 0)
                    Mouse.TurnLeft();
                else
                    Mouse.TurnRight();
        }

        public void YouWin()
        {
            
        }

        public void YouLoose()
        {
            
        }
    }
}
