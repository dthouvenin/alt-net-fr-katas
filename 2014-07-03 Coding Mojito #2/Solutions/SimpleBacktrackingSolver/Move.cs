using System;

namespace Altnet.Katas.CodingMojito
{
    public class Move
    {
        public Direction Direction { get; set; }
        public PathNode PathNode { get; set; }

        public Move(Direction direction, PathNode pathNode)
        {
            Direction = direction;
            PathNode = pathNode;
        }
    }
}