using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mazes.Core
{
    public interface IMouse
    {
        void TurnLeft();
        void TurnRight();
        void Move();
    }
}
