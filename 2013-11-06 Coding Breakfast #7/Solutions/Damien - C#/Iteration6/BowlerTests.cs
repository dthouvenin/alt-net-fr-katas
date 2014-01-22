using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace Bowling.Iteration6
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

            Assert.AreEqual(12 + 5, score);
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

        [Test]
        public void Throws_Are_Displayed_With_Number_Of_Pins()
        {
            var bowler = new Bowler();

            bowler.Throw(1);
            bowler.Throw(3);

            Assert.AreEqual("1|3", bowler.Display);
        }

        [Test]
        public void Spares_Are_Displayed_With_Number_Of_Pins_Plus_Slash()
        {
            var bowler = new Bowler();

            bowler.Throw(1);
            bowler.Throw(9);

            Assert.AreEqual("1|/", bowler.Display);
        }

        [Test]
        public void Open_Frame_Is_Displayed_With_Underscore()
        {
            var bowler = new Bowler();

            bowler.Throw(1);
            bowler.Throw(3);
            bowler.Throw(4);

            Assert.AreEqual("1|3 4|_", bowler.Display);
        }

        [Test]
        public void Ten_Pins_In_A_Frame_Is_A_Spare()
        {
            var bowler = new Bowler();

            bowler.Throw(1);
            bowler.Throw(8);
            bowler.Throw(1);
            bowler.Throw(9);

            Assert.IsFalse(bowler[1].IsSpare);
            Assert.IsTrue(bowler[2].IsSpare);
        }

        [Test]
        public void Score_For_A_Spare_Is_Ten_Plus_Next_Throw()
        {
            var bowler = new Bowler();

            bowler.Throw(1);
            bowler.Throw(9);
            bowler.Throw(3);
            bowler.Throw(5);

            Assert.AreEqual(13, bowler[1].Score);
        }

        [Test]
        public void Ten_Pins_Set_On_First_Throw_Of_A_Frame_Is_A_Strike()
        {
            var bowler = new Bowler();

            bowler.Throw(10);

            Assert.IsTrue(bowler[1].IsStrike);
            Assert.IsFalse(bowler[1].IsSpare);
        }

        [Test]
        public void A_Strike_Is_A_Full_Frame()
        {
            var bowler = new Bowler();

            bowler.Throw(10);

            Assert.IsFalse(bowler[1].IsOpen);
            Assert.AreEqual(2, bowler.FrameNo);
        }

        [Test]
        public void Score_For_A_Strike_Is_Ten_Plus_Next_Two_Throws()
        {
            var bowler = new Bowler();

            bowler.Throw(10);
            bowler.Throw(3);
            bowler.Throw(4);

            Assert.AreEqual(17, bowler[1].Score);
        }

        [Test]
        public void Score_For_A_Strike_Is_Unknown_Until_Next_Two_Throws()
        {
            var bowler = new Bowler();

            bowler.Throw(10);
            var score1 = bowler[1].Score;
            bowler.Throw(3);
            var score2 = bowler[1].Score;
            bowler.Throw(4);

            Assert.IsNull(score1);
            Assert.IsNull(score2);
            Assert.AreEqual(17, bowler[1].Score);
        }

    }
}
