using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mazes.Core;

namespace Maze.Tests
{
    class SimpleMazeBuilder : IMazeBuilder
    {
        public int Height
        {
            get { return 3; }
        }

        public int Width
        {
            get { return 3; }
        }

        public void Build(IBuildableMaze maze)
        {
            /*
                _ _ _
               |> _| |
               |_   _| 
               |_ _  |
  
             */
            maze.AddHorizontalWall(0, 0);
            maze.AddHorizontalWall(1, 0);
            maze.AddHorizontalWall(2, 0);
            maze.AddHorizontalWall(1, 1);
            maze.AddHorizontalWall(0, 2);
            maze.AddHorizontalWall(2, 2);
            maze.AddHorizontalWall(0, 3);
            maze.AddHorizontalWall(1, 3);

            maze.AddVerticalWall(0, 0);
            maze.AddVerticalWall(2, 0);
            maze.AddVerticalWall(3, 0);
            maze.AddVerticalWall(0, 1);
            maze.AddVerticalWall(3, 1);
            maze.AddVerticalWall(0, 2);
            maze.AddVerticalWall(3, 2);
        }

        public Position MazeStartPosition
        {
            get { return new Position(0, 0); }
        }
    }

    
}
