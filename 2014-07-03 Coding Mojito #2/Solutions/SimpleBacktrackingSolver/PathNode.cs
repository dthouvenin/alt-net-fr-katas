using System;
using System.Collections.Generic;

namespace Altnet.Katas.CodingMojito
{
    public class PathNode
    {
        public Coordinates Coordinates { get; set; }
        public List<Direction> OpenDirections { get; set; }
        public Dictionary<Direction, PathNode> RoutesTaken { get; set; }
        public Move Origin { get; set; }

        public PathNode()
        {
            OpenDirections = new List<Direction>();
            RoutesTaken = new Dictionary<Direction, PathNode>();
        }
    }
}