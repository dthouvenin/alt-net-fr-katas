using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mazes.Core
{
    public enum Direction : int
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    };

    public interface IWatchableMaze
    {
        void Subscribe(IMazeWatcher watcher);
        void Unsubscribe(IMazeWatcher watcher);
        void Draw(IMazeDrawer drawer);
    }
    public interface IMazeDrawer
    {
        void DrawWall(Position fromPos, Position toPos);
        void DrawMouse(Position position, Direction direction);
    }
    public interface IMazeWatcher
    {
        void MazeHasBeenBuilt(int with, int height);
        
        void MouseWantsToMove();
        void MouseHasMoved(Position newPosition);
        void MouseHasTurned(Direction newDirection);
        void MouseHasExitedMaze();
        
        void YouHaveBeenUnsubscribed();
    }
}
