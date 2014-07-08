using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Mazes.Core;

namespace Altnet.Katas.CodingMojito
{
    public class SimpleBacktrackingSolver : IMazeSolver
    {
        private IMaze maze;
        private IMouse mouse;
        private PathNode pathRoot;

        private Direction currentDirection;
        private PathNode currentNode;
        private Dictionary<Coordinates, PathNode> nodesVisited;
        private Coordinates currentCoordinates;

        public void Init(IMaze maze, IMouse mouse)
        {
            this.mouse = new DebuggingMouse(mouse);
            this.maze = maze;
            currentCoordinates = Coordinates.Zero;
            currentDirection = Direction.East;
            pathRoot = CreateNodeFromCurrentPosition(null);
            currentNode = pathRoot;
            nodesVisited = new Dictionary<Coordinates, PathNode>
            {
                { currentCoordinates, pathRoot},
            };
        }

        public PathNode CreateNodeFromCurrentPosition(PathNode origin)
        {
            var node = new PathNode
            {
                Coordinates = currentCoordinates,
                Origin = new Move(origin == null ? null : origin.Coordinates.GetDirectionTo(currentCoordinates), origin),
            };
            FindOpenDirectionsOfNode(node);
            return node;
        }

        private int turn;

        public void YourTurn()
        {
            Debug.WriteLine("Turn {0}. At {1}, facing {2}", ++turn, currentCoordinates, currentDirection);
            // Find out directions which are available (not blocked by a wall), and not the direction we are coming from
            var nextMove = currentNode.OpenDirections.FirstOrDefault(n => !currentNode.RoutesTaken.ContainsKey(n));
            if (nextMove != null)
            {
                Debug.WriteLine("Turn {0}. Next move : {1}", turn, nextMove);
                // Move and update state accordingly
                Face(nextMove);
                Move();
                var nextNode = UpdateNextNode();
                currentNode.RoutesTaken.Add(currentDirection, nextNode);
                currentNode = nextNode;
            }
            else
            {
                Debug.WriteLine("Turn {0}. Backtracking", turn);
                GoBack();
            }
        }

        private PathNode UpdateNextNode()
        {
            PathNode nextNode;
            if (nodesVisited.TryGetValue(currentCoordinates, out nextNode))
            {
                // Recalculate open directions since we are not coming from the same direction
                FindOpenDirectionsOfNode(nextNode);
            }
            else
            {
                // Never visited that node, create a new one
                nextNode = CreateNodeFromCurrentPosition(currentNode);
                nodesVisited.Add(currentCoordinates, nextNode);
            }
            return nextNode;
        }

        private void GoBack()
        {
            if (currentNode.Origin == null)
                return;

            Coordinates previousCoordinates = currentNode.Origin.PathNode != null
                ? currentNode.Origin.PathNode.Coordinates
                : Coordinates.Zero;

            if (previousCoordinates.IsWestOf(currentCoordinates))
            {
                Face(Direction.East);
                Move();
            }
            else if (previousCoordinates.IsEastOf(currentCoordinates))
            {
                Face(Direction.West);
                Move();
            }
            else if (previousCoordinates.IsNorthOf(currentCoordinates))
            {
                Face(Direction.South);
                Move();
            }
            else
            {
                Face(Direction.North);
                Move();
            }

            currentNode = currentNode.Origin.PathNode;
        }

        private void Face(Direction nextMove)
        {
            // TODO: Obvious optimization here
            while (currentDirection != nextMove)
            {
                TurnRight();
            }
        }

        private void FindOpenDirectionsOfNode(PathNode node)
        {
            node.OpenDirections.Clear();
            // Turn around 360° and look whether the path is open or not, and whether it's the direction
            // we are coming from.
            // TODO : we could store that instead of recalculating it every time
            for (int i = 0; i < 4; i++)
            {
                if (maze.CanIMove() && (node.Origin == null || currentDirection != node.Origin.Direction))
                {
                    node.OpenDirections.Add(currentDirection);
                }
                TurnRight();
            }
        }
        
        public void Move()
        {
            mouse.Move();
            currentCoordinates = currentCoordinates.Move(currentDirection);
        }

        private void TurnRight()
        {
            mouse.TurnRight();
            currentDirection = currentDirection.TurnRight();
        }

        public void YouWin()
        {
        }

        public void YouLoose()
        {
        }
    }
}
