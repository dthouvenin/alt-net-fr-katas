using System;
using System.Collections.Generic;
using System.Linq;

namespace TradingCardGame
{
    public enum Status
    {
        Alive,
        Dead
    }

    public class Player
    {
        public int Id { get; private set; }

        public Status Status { get { return Points > 0 ? Status.Alive : Status.Dead; } }

        public int Points { get; set; }

        public List<ManaSlot> ManaSlots { get; set; }

        public Deck Deck { get; private set; }

        public List<DomageCard> Hand { get; set; }

        public Player(int id)
        {
            this.Id = id;
            GenerateDeck();

            Points = 30;

            ManaSlots = new List<ManaSlot>();
            Hand = new List<DomageCard>();
        }

        private void GenerateDeck()
        {
            Deck = new Deck
            {
                Cards = new Queue<DomageCard>()
            };

            var manaCoutList = new List<int> { 0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8 };
            var random = new Random();

            for (int i = 0; i < 20; i++)
            {
                var rd = random.Next(manaCoutList.Count);
                var manaCout = manaCoutList[rd];

                Deck.Cards.Enqueue(new DomageCard { ManaNeededToInvoke = manaCout });

                manaCoutList.Remove(manaCout);
            }
        }

        public void TakeCard()
        {
            var card = Deck.Cards.Dequeue();

            Hand.Add(card);
        }

        internal IEnumerable<DomageCard> GetPlayableCards()
        {
            var activeManaCount = ManaSlots.Count(a => a.Active);

            if (activeManaCount != 0)
                foreach (var c in Hand)
                {
                    if (c.ManaNeededToInvoke <= activeManaCount)
                    {
                        yield return c;
                    }
                }
        }
    }

    public class ManaSlot
    {
        public bool Active { get; set; }
    }
}