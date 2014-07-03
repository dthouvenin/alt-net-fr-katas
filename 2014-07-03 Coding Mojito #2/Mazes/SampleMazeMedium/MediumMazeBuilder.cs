using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mazes.Core;

namespace SampleMazeMedium
{
    public class MediumMazeBuilder : IMazeBuilder
    {
        public int Height
        {
            get { return 3; }
        }

        public int Width
        {
            get { return 8; }
        }

        public void Build(IBuildableMaze maze)
        {
            /*
                _ _ _ _ _ _ _ _ 
               |x _| |   |   | |
               |_   _| |   | |
               |_ _ _ _|_|_|_ _| 
  
             */
            maze.AddHorizontalWall(0, 0);
            maze.AddHorizontalWall(1, 0);
            maze.AddHorizontalWall(2, 0);
            maze.AddHorizontalWall(3, 0);
            maze.AddHorizontalWall(4, 0);
            maze.AddHorizontalWall(5, 0);
            maze.AddHorizontalWall(6, 0);
            maze.AddHorizontalWall(7, 0);
            maze.AddHorizontalWall(1, 1);
            maze.AddHorizontalWall(0, 2);
            maze.AddHorizontalWall(2, 2);
            maze.AddHorizontalWall(0, 3);
            maze.AddHorizontalWall(1, 3);
            maze.AddHorizontalWall(2, 3);
            maze.AddHorizontalWall(3, 3);
            maze.AddHorizontalWall(4, 3);
            maze.AddHorizontalWall(5, 3);
            maze.AddHorizontalWall(6, 3);
            maze.AddHorizontalWall(7, 3);

            maze.AddVerticalWall(0, 0);
            maze.AddVerticalWall(2, 0);
            maze.AddVerticalWall(3, 0);
            maze.AddVerticalWall(0, 1);
            maze.AddVerticalWall(3, 1);
            maze.AddVerticalWall(0, 2);
            maze.AddVerticalWall(4, 1);
            maze.AddVerticalWall(4, 2);
            maze.AddVerticalWall(5, 0);
            maze.AddVerticalWall(5, 2);
            maze.AddVerticalWall(6, 1);
            maze.AddVerticalWall(6, 2);
            maze.AddVerticalWall(7, 0);
            maze.AddVerticalWall(7, 1);
            maze.AddVerticalWall(8, 0);
            maze.AddVerticalWall(8, 2);
        }

        public Position MazeStartPosition
        {
            get { return new Position(0, 0); }
        }
    }

}
