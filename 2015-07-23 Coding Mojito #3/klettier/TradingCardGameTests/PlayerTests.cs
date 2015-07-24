using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCardGame;
using Xunit;

namespace TradingCardGameTests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_start_with_30_life_points()
        {
            var p = new Player(1);

            Assert.Equal(30, p.Points);
        }

        [Fact]
        public void Player_start_with_0_mana_slot()
        {
            var p = new Player(1);

            Assert.Equal(0, p.ManaSlots.Count);
        }

        [Fact]
        public void Player_start_with_20_cards_deck()
        {
            var p = new Player(1);

            Assert.Equal(20, p.Deck.Cards.Count);
        }
    }
}
