using System;
using System.Collections.Generic;
using System.Linq;

namespace TradingCardGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var g = new Game(2);

            while (g.Status != GameStatus.Ended)
            {
                g.PlayTurn((playableCards, enemies) =>
                    {
                         if(g.CurrentTurn.IsNewTurn)
                        Console.WriteLine("********************************************************************************");

                        if (playableCards.Length > 0 && enemies.Length > 0)
                        {
                            Console.WriteLine("Current player ({0}) has {1} points left", g.CurrentPlayer.Id, g.CurrentPlayer.Points);

                            foreach (var e in enemies)
                            {
                                Console.WriteLine("Player {0} has {1} points left", e.Id, e.Points);
                            }

                            var selectedEnemy = enemies.Where(s => s.Points > 0).OrderByDescending(s => s.Points).First();

                            var card = playableCards.OrderByDescending(s => s.ManaNeededToInvoke == selectedEnemy.Points).First();

                            Console.WriteLine("***********************Player {0} deal {1} domage to player {2}***********************", g.CurrentPlayer.Id, card.ManaNeededToInvoke, selectedEnemy.Id);

                            return Tuple.Create(card, selectedEnemy);
                        }

                        return null;
                    });
            }

            Console.WriteLine("Player {0} wins with {1} life point(s) left !", g.CurrentPlayer.Id, g.CurrentPlayer.Points);
        }
    }
}