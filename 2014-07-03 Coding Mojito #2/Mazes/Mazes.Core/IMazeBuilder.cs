using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mazes.Core
{
    public struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public readonly int X;
        public readonly int Y;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var p2 = obj as Position?;
            if (!p2.HasValue) return false;
            return (this.X == p2.Value.X) && (this.Y == p2.Value.Y);
        }

        public override int GetHashCode()
        {
            return (this.X * 37) ^ (this.Y);
        }
    }

    public interface IMazeBuilder
    {
        /// <summary>
        /// Called upon initialization of the maze, before it gets built. Provides the number of cells of the maze on the x axis
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Called upon initialization of the maze, before it gets built. Provides the number of cells of the maze on the y axis
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Called by an empty maze to be built
        /// </summary>
        /// <param name="maze">Maze that is being built. Maze originally has no walls. Call <code>AddVerticalWall</code> or <code>AddHorizontalWall</code> to add walls</param>
        void Build(IBuildableMaze maze);
        
        /// <summary>
        /// Provides the builder's prefered start position for the mouse. Called after the maze has been built. By convention, the mouse is always looking eastward at the start.
        /// </summary>
        Position MazeStartPosition { get; }
    }
}
