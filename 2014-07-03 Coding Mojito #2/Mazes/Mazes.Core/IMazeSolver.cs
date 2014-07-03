using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mazes.Core
{
    public interface IMazeSolver
    {
        void Init(IMaze maze, IMouse mouse);
        void YourTurn();
        void YouWin();
        void YouLoose();
    }
}
