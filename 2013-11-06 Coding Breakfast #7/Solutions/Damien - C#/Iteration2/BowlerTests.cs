using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace Bowling.Iteration2
{
    [TestFixture]
    public class BowlerTests
    {
        [Test]
        public void Score_For_A_Throw_Is_NumBer_Of_Pins_Set()
        {
            var bowler = new Bowler();

            bowler.Throw(5);
            bowler.Throw(3);
            var score = bowler.Score;

            Assert.AreEqual(8, score);
        }

        [Test]
        public void Two_Throws_Are_A_Frame()
        {
            var bowler = new Bowler();

            var frameInitial = bowler.FrameNo;
            bowler.Throw(1);
            var frameAfterThrowOne = bowler.FrameNo;
            bowler.Throw(1);
            var frameAfterThrowTwo = bowler.FrameNo;
            bowler.Throw(1);
            var frameAfterThrowThree = bowler.FrameNo;
            bowler.Throw(1);
            var frameAfterThrowFour = bowler.FrameNo;

            Assert.AreEqual(1, frameInitial);
            Assert.AreEqual(1, frameAfterThrowOne);
            Assert.AreEqual(2, frameAfterThrowTwo);
            Assert.AreEqual(2, frameAfterThrowThree);
            Assert.AreEqual(3, frameAfterThrowFour);
        }

    }
}
