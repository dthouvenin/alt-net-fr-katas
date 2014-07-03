using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mazes.Core;

namespace SampleComplexMaze
{
    public class MediumMazeBuilder : IMazeBuilder
    {
        public int Height
        {
            get { return 10; }
        }

        public int Width
        {
            get { return 9; }
        }

        public void Build(IBuildableMaze maze)
        {
            maze.AddHorizontalWall(0, 0);
            maze.AddHorizontalWall(1, 0);
            maze.AddHorizontalWall(2, 0);
            maze.AddHorizontalWall(3, 0);
            maze.AddHorizontalWall(4, 0);
            maze.AddHorizontalWall(5, 0);
            maze.AddHorizontalWall(6, 0);
            maze.AddHorizontalWall(7, 0);
            maze.AddHorizontalWall(8, 0);

            maze.AddHorizontalWall(2, 1);
            maze.AddHorizontalWall(3, 1);
            maze.AddHorizontalWall(4, 1);
            maze.AddHorizontalWall(5, 1);
            maze.AddHorizontalWall(6, 1);
            maze.AddHorizontalWall(7, 1);

            maze.AddHorizontalWall(1, 2);
            maze.AddHorizontalWall(2, 2);
            maze.AddHorizontalWall(3, 2);

            maze.AddHorizontalWall(5, 2);
            maze.AddHorizontalWall(6, 2);
            maze.AddHorizontalWall(7, 2);

            maze.AddHorizontalWall(0, 3);

            maze.AddHorizontalWall(2, 3);
            maze.AddHorizontalWall(3, 3);
            maze.AddHorizontalWall(4, 3);
            maze.AddHorizontalWall(5, 3);

            maze.AddHorizontalWall(8, 3);

            maze.AddHorizontalWall(3, 4);
            maze.AddHorizontalWall(5, 4);

            maze.AddHorizontalWall(4, 6);

            maze.AddHorizontalWall(3, 7);
            maze.AddHorizontalWall(5, 7);

            maze.AddHorizontalWall(3, 8);
            maze.AddHorizontalWall(4, 8);
            maze.AddHorizontalWall(5, 8);
            maze.AddHorizontalWall(6, 8);

            maze.AddHorizontalWall(1, 9);
            maze.AddHorizontalWall(2, 9);
            maze.AddHorizontalWall(3, 9);

            maze.AddHorizontalWall(5, 9);
            maze.AddHorizontalWall(6, 9);
            maze.AddHorizontalWall(7, 9);

            maze.AddHorizontalWall(0, 10);
            maze.AddHorizontalWall(1, 10);
            maze.AddHorizontalWall(2, 10);
            maze.AddHorizontalWall(3, 10);
            maze.AddHorizontalWall(4, 10);
            maze.AddHorizontalWall(5, 10);
            maze.AddHorizontalWall(6, 10);
            maze.AddHorizontalWall(7, 10);
            maze.AddHorizontalWall(8, 10);

            maze.AddVerticalWall(0, 0);
            maze.AddVerticalWall(0, 1);
            maze.AddVerticalWall(0, 3);
            maze.AddVerticalWall(0, 4);
            maze.AddVerticalWall(0, 5);
            maze.AddVerticalWall(0, 6);
            maze.AddVerticalWall(0, 7);
            maze.AddVerticalWall(0, 8);
            maze.AddVerticalWall(0, 9);

            maze.AddVerticalWall(1, 2);
            maze.AddVerticalWall(1, 3);
            maze.AddVerticalWall(1, 4);

            maze.AddVerticalWall(1, 6);
            maze.AddVerticalWall(1, 7);
            maze.AddVerticalWall(1, 8);

            maze.AddVerticalWall(2, 1);

            maze.AddVerticalWall(2, 4);
            maze.AddVerticalWall(2, 5);
            maze.AddVerticalWall(2, 6);
            maze.AddVerticalWall(2, 7);

            maze.AddVerticalWall(3, 4);
            maze.AddVerticalWall(3, 6);

            maze.AddVerticalWall(4, 5);

            maze.AddVerticalWall(5, 5);

            maze.AddVerticalWall(6, 4);
            maze.AddVerticalWall(6, 6);

            maze.AddVerticalWall(7, 3);
            maze.AddVerticalWall(7, 4);
            maze.AddVerticalWall(7, 5);
            maze.AddVerticalWall(7, 6);

            maze.AddVerticalWall(8, 2);
            maze.AddVerticalWall(8, 3);
            maze.AddVerticalWall(8, 4);

            maze.AddVerticalWall(8, 6);
            maze.AddVerticalWall(8, 7);
            maze.AddVerticalWall(8, 8);

            maze.AddVerticalWall(9, 0);
            maze.AddVerticalWall(9, 1);
            maze.AddVerticalWall(9, 2);
            maze.AddVerticalWall(9, 3);
            maze.AddVerticalWall(9, 4);
            maze.AddVerticalWall(9, 5);
            maze.AddVerticalWall(9, 6);
            maze.AddVerticalWall(9, 7);
            maze.AddVerticalWall(9, 8);
            maze.AddVerticalWall(9, 9);
        }

        public Position MazeStartPosition
        {
            get { return new Position(4, 5); }
        }
    }
}
