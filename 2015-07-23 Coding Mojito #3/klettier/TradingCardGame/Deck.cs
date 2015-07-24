using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCardGame
{
   public class Deck
    {
        public Queue<DomageCard> Cards { get; set; }
    }

   public class DomageCard
    {
        public int ManaNeededToInvoke { get; set; }

        public void DealDomage(Player selectedEnemy)
        {
            selectedEnemy.Points -= ManaNeededToInvoke;
        }
    }
}
