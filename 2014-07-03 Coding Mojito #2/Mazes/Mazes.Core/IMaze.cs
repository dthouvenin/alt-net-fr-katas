using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mazes.Core
{
    public interface IMaze
    {
        bool CanIMove();
        bool AmIOut();
    }

    public interface IBuildableMaze
    {
        void AddVerticalWall(int width, int height);
        void AddHorizontalWall(int width, int height);
    }    
}
