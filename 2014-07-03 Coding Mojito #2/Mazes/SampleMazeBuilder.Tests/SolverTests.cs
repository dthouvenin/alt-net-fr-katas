using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Mazes.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleMazeBuilder.Tests
{
    [TestClass]
    public class SolverTests
    {
        private enum Action
        {
            Move,
            Left,
            Right
        };
        class FakeMouse: IMouse
        {
            public readonly List<Action> Actions = new List<Action>();

            public void TurnLeft()
            {
                Actions.Add(Action.Left);
            }

            public void TurnRight()
            {
                Actions.Add(Action.Right);
            }

            public void Move()
            {
                Actions.Add(Action.Move);
            }
        }
        [TestMethod]
        public void SolverDoesRightMoveLeftMoveAndRepeat()
        {
            var fakeMouse = new FakeMouse();
            var solver = new HardCodedSolverForSimpleMaze();

            solver.Init(null, fakeMouse);
            for (int i = 0; i < 20; i++)
            {
                solver.YourTurn();
            }

            Assert.AreEqual(20, fakeMouse.Actions.Count);
            Assert.AreEqual(Action.Right, fakeMouse.Actions[0]);
            Assert.AreEqual(Action.Move, fakeMouse.Actions[1]);
            Assert.AreEqual(Action.Left, fakeMouse.Actions[2]);
            Assert.AreEqual(Action.Move, fakeMouse.Actions[3]);
            Assert.AreEqual(Action.Right, fakeMouse.Actions[4]);
            Assert.AreEqual(Action.Move, fakeMouse.Actions[5]);
            Assert.AreEqual(Action.Left, fakeMouse.Actions[6]);
            Assert.AreEqual(Action.Move, fakeMouse.Actions[7]);
            Assert.AreEqual(Action.Right, fakeMouse.Actions[8]);
            Assert.AreEqual(Action.Move, fakeMouse.Actions[9]);
            Assert.AreEqual(Action.Left, fakeMouse.Actions[10]);
            Assert.AreEqual(Action.Move, fakeMouse.Actions[11]);
            Assert.AreEqual(Action.Right, fakeMouse.Actions[12]);
            Assert.AreEqual(Action.Move, fakeMouse.Actions[13]);
            Assert.AreEqual(Action.Left, fakeMouse.Actions[14]);
            Assert.AreEqual(Action.Move, fakeMouse.Actions[15]);
            Assert.AreEqual(Action.Right, fakeMouse.Actions[16]);
            Assert.AreEqual(Action.Move, fakeMouse.Actions[17]);
            Assert.AreEqual(Action.Left, fakeMouse.Actions[18]);
            Assert.AreEqual(Action.Move, fakeMouse.Actions[19]);            
        }
    }
}
