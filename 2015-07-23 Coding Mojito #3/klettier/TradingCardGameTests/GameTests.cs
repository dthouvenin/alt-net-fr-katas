using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCardGame;
using Xunit;

namespace TradingCardGameTests
{
    public class GameTests
    {
        [Fact]
        public void Player_one_begins_game_with_3_cards()
        {
            var game = new Game(3);

            Assert.Equal(3, game.Players.First().Hand.Count);
        }

        [Fact]
        public void Players_other_than_first_begin_with_4_cards()
        {
            var game = new Game(3);

            foreach (var p in game.Players.Skip(1))
            {
                Assert.Equal(4, p.Hand.Count);
            }
        }
    }
}