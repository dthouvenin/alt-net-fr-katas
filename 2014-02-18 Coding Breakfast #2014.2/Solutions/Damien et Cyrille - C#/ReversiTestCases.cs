using System;
using System.Collections.Generic;
using System.Text;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;

namespace Reversi
{
    [TestFixture]
    public class ReversiTestCases
    {
        [Test]
        public void New_Board_Is_All_Empty_Bu_The_Four_Central_Positions()
        {
            var board = new ReversiBoard();

            for (var col = 0; col < 8;col++ )
            {
                for(var row=0;row<8;row++)
                {
                    if ((col == 3 || col == 4) && (row == 3 || row == 4))
                        continue;
                    Assert.AreEqual(Box.Empty, board[col, row]);
                }
            }                
        }
        
        [Test]
        public void When_New_Board_And_Considering_First_Black_There_Are_5_Eligible_Positions()
        {
            var board = new ReversiBoard();

            var results = new List<Position>(board.PotentialPositionsFor(3, 3));

            Assert.AreEqual(5, results.Count);
            Assert.AreEqual(2, results[0].Col); Assert.AreEqual(2, results[0].Row);
            Assert.AreEqual(3, results[1].Col); Assert.AreEqual(2, results[1].Row);
            Assert.AreEqual(4, results[2].Col); Assert.AreEqual(2, results[2].Row);
            Assert.AreEqual(2, results[3].Col); Assert.AreEqual(4, results[3].Row);
            Assert.AreEqual(2, results[4].Col); Assert.AreEqual(3, results[4].Row);            
        }

        [Test]
        public void When_New_Board_And_Considering_First_Black_There_Are_2_Valid_Positions()
        {
            var board = new ReversiBoard();

            var results = new List<Position>(board.ValidPositionsFor(3, 3));
            /*
                . . . . . . . .
                . . . . . . . .
                . . . x . . . .
                . . x N B . . .
                . . . B N . . .
                . . . . . . . .
                . . . . . . . .
             */ 
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(3, results[0].Col); Assert.AreEqual(2, results[0].Row);
            Assert.AreEqual(2, results[1].Col); Assert.AreEqual(3, results[1].Row);
        }
    }
}
