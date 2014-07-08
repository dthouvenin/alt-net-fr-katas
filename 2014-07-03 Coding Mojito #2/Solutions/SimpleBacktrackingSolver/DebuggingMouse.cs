using System;
using System.Diagnostics;
using Mazes.Core;

namespace Altnet.Katas.CodingMojito
{
    public class DebuggingMouse : IMouse
    {
        private readonly IMouse mouse;

        public DebuggingMouse(IMouse mouse)
        {
            this.mouse = mouse;
        }

        public void TurnLeft()
        {
            mouse.TurnLeft();
            Debug.WriteLine("Turned left");
        }

        public void TurnRight()
        {
            mouse.TurnRight();
            Debug.WriteLine("Turned right");
        }

        public void Move()
        {
            mouse.Move();
            Debug.WriteLine("Moved");
        }
    }
}