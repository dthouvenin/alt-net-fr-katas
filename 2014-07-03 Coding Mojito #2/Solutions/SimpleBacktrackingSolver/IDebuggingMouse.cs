using System;
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
            Console.WriteLine("Turned left");
        }

        public void TurnRight()
        {
            mouse.TurnRight();
            Console.WriteLine("Turned right");
        }

        public void Move()
        {
            mouse.Move();
            Console.WriteLine("Moved");
        }
    }
}