﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Mazes.Core;

namespace Altnet.Katas.CodingMojito
{
    public enum Direction
    {
        East,
        South,
        West,
        North
    }

    public class Coordinates
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        protected bool Equals(Coordinates other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Coordinates) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X*397) ^ Y;
            }
        }
    }

    public class PathNode
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<Direction> OpenDirections { get; set; }
        public Dictionary<Direction, PathNode> RoutesTaken { get; set; }
        public Tuple<Direction, PathNode> Origin { get; set; }

        public PathNode()
        {
            OpenDirections = new List<Direction>();
            RoutesTaken = new Dictionary<Direction, PathNode>();
        }
    }
    
    public class SimpleBacktrackingSolver : IMazeSolver
    {
        private IMaze maze;
        private IMouse mouse;

        private PathNode pathRoot = null;
        
        public void Init(IMaze maze, IMouse mouse)
        {
            this.mouse = mouse;
            this.maze = maze;
            currentX = 0;
            currentY = 0;
            currentDirection = Direction.East;
            pathRoot = CreateNodeFromCurrentPosition(null);
            currentNode = pathRoot;
            nodesVisited = new Dictionary<Coordinates, PathNode>
            {
                { new Coordinates(0,0), pathRoot},
            };
        }

        private int currentX, currentY;
        private Direction currentDirection;
        private PathNode currentNode;
        private Dictionary<Coordinates, PathNode> nodesVisited;

        public PathNode CreateNodeFromCurrentPosition(PathNode origin)
        {
            var node = new PathNode()
            {
                X = currentX,
                Y = currentY,
                Origin = new Tuple<Direction, PathNode>(GetDirectionOfOrigin(), origin),
            };
            FindOpenDirectionsOfNode(node);
            return node;
        }

        private Direction GetDirectionOfOrigin()
        {
            return Invert(currentDirection);
        }

        public void YourTurn()
        {
            // Find out directions which are available (not blocked by a wall), and not the direction we are coming from
			var nextMove = currentNode.OpenDirections.Cast<Direction?>().FirstOrDefault(n => !currentNode.RoutesTaken.ContainsKey(n.Value));
            if (nextMove != null)
            {
				Face(nextMove.Value);
                Move();
                var nextNode = UpdateNextNode();
                currentNode.RoutesTaken.Add(currentDirection, nextNode);
                currentNode = nextNode;
            }
            else
            {
                GoBack();
            }
        }

        private PathNode UpdateNextNode()
        {
            PathNode nextNode;
            var currentCoordinates = new Coordinates(currentX, currentY);
            if (nodesVisited.TryGetValue(currentCoordinates, out nextNode))
            {
                FindOpenDirectionsOfNode(nextNode);
            }
            else
            {
                nextNode = CreateNodeFromCurrentPosition(currentNode);
                nodesVisited.Add(currentCoordinates, nextNode);
            }
            return nextNode;
        }

        private void GoBack()
        {
            if (currentNode.Origin.Item2.X > currentX)
            {
                Face(Direction.East);
                Move();
            }
            else if (currentNode.Origin.Item2.X < currentX)
            {
                Face(Direction.West);
                Move();
            }
            else if (currentNode.Origin.Item2.Y > currentY)
            {
                Face(Direction.South);
                Move();
            }
            else
            {
                Face(Direction.North);
                Move();
            }

            currentNode = currentNode.Origin.Item2;
        }

        private void Face(Direction nextMove)
        {
            while (currentDirection != nextMove)
            {
                TurnRight();
            }
        }

        private void FindOpenDirectionsOfNode(PathNode node)
        {
            for (int i = 0; i < 4; i++)
            {
                if (maze.CanIMove() && (node.Origin == null || currentDirection != node.Origin.Item1))
                {
                    node.OpenDirections.Add(currentDirection);
                }
                TurnRight();
            }
        }

        private Direction Invert(Direction direction)
        {
            switch (direction)
            {
                case Direction.East:
                    return Direction.West;
                case Direction.South:
                    return Direction.North;
                case Direction.West:
                    return Direction.East;
                case Direction.North:
                    return Direction.South;
            }

            throw new NotImplementedException();
        }

        public void Move()
        {
            mouse.Move();
            switch (currentDirection)
            {
                case Direction.East:
                    currentX++;
                    break;
                case Direction.South:
                    currentY++;
                    break;
                case Direction.West:
                    currentX--;
                    break;
                case Direction.North:
                    currentY--;
                    break;
            }
        }

        private void TurnRight()
        {
            mouse.TurnRight();
            switch (currentDirection)
            {
                case Direction.East:
                    currentDirection = Direction.South;
                    break;
                case Direction.South:
                    currentDirection = Direction.West;
                    break;
                case Direction.West:
                    currentDirection = Direction.North;
                    break;
                case Direction.North:
                    currentDirection = Direction.East;
                    break;
            }
        }

        private void TurnLeft()
        {
            mouse.TurnLeft();
            switch (currentDirection)
            {
                case Direction.East:
                    currentDirection = Direction.North;
                    break;
                case Direction.South:
                    currentDirection = Direction.East;
                    break;
                case Direction.West:
                    currentDirection = Direction.South;
                    break;
                case Direction.North:
                    currentDirection = Direction.West;
                    break;
            }
        }

        //private bool TryMove()
        //{
        //    if (!maze.CanIMove())
        //    {
        //        return false;
        //    }

        //    // Already tried this move earlier ?
        //    if(previousMoves.Any(move => move.X == currentX && move.Y == currentY && move.Direction == currentDirection))
        //    {
        //        return false; 
        //    }
            
        //    mouse.Move();

        //    Console.WriteLine("Mouse at [{0}, {1}], facing {2}", currentX, currentY, currentDirection);

        //    previousMoves.Add(new Move {X = currentX, Y = currentY, Direction = currentDirection});
          
        //    return true;
        //}

        public void YouWin()
        {
        }

        public void YouLoose()
        {
        }
    }
}
