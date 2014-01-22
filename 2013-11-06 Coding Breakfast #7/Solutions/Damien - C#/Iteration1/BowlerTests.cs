using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace Bowling.Iteration1
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

    }
}
