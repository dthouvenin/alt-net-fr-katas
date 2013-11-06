using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace Bowling.Iteration3
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

        [Test]
        public void Two_Throws_In_A_Frame_That_Total_Up_To_Ten_Score_Ten_Plus_Pins_Set_In_Next_Throw()
        {
            var bowler = new Bowler();

            bowler.Throw(9);
            bowler.Throw(1);  // spare
            bowler.Throw(2);
            bowler.Throw(3);

            var score = bowler.Score;
            
            Assert.AreEqual(12+5, score);
        }

        [Test]
        public void Even_Number_Of_Throws_Give_A_Unknown_Score()
        {
            var bowler = new Bowler();

            bowler.Throw(4);
            bowler.Throw(3);  
            bowler.Throw(2);

            var score = bowler.Score;

            Assert.IsNull(score);
        }

        [Test]
        public void When_Last_Frame_Is_A_Spare_Score_Is_Unknown_Until_Next_Throw()
        {
            var bowler = new Bowler();

            bowler.Throw(9);
            bowler.Throw(1); // spare

            var score = bowler.Score;

            Assert.IsNull(score);
        }

    }
}
