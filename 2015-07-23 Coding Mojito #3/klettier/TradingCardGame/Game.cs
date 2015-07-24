using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TradingCardGame
{
    public enum GameStatus
    {
        NotStart,
        Started,
        Ended
    }

    public class Game
    {
        public GameStatus Status { get; set; }

        public ReadOnlyCollection<Player> Players { get; set; }

        public Player CurrentPlayer { get; private set; }

        public Turn CurrentTurn { get; private set; }

        public List<Turn> PlayedTours { get; set; }

        private Queue<Player> playersRotation;

        public Game(int numberOfPlayers)
        {
            Players = new ReadOnlyCollection<Player>(Enumerable.Range(1, numberOfPlayers).Select(s => CreatePlayer(s)).ToArray());

            Initialize();

            Status = GameStatus.NotStart;

            PlayedTours = new List<Turn>();
        }

        private Player CreatePlayer(int id)
        {
            var player = new Player(id);

            for (int i = 0; i < 3; i++)
            {
                player.TakeCard();
            }

            return player;
        }

        private void Initialize()
        {
            playersRotation = new Queue<Player>(Players.OrderBy(s => new Guid()));

            foreach (var p in playersRotation.Skip(1))
            {
                p.TakeCard();
            }
        }

        public void PlayTurn(Func<DomageCard[], Player[], Tuple<DomageCard, Player>> play)
        {
            if (Status == GameStatus.NotStart)
            {
                Status = GameStatus.Started;
            }
            else if (Status == GameStatus.Ended)
            {
                throw new InvalidOperationException("Game already ended");
            }

            CurrentPlayer = playersRotation.Dequeue();

            var turn = new Turn(CurrentPlayer);

            CurrentTurn = turn;

            turn.Play(play, playersRotation.ToArray());

            PlayedTours.Add(turn);

            playersRotation = new Queue<Player>(playersRotation.Where(s => s.Status == TradingCardGame.Status.Alive));

            playersRotation.Enqueue(CurrentPlayer);

            EvaluateEndOfGame();
        }

        void EvaluateEndOfGame()
        {
            var winners = playersRotation.Where(s => s.Status == TradingCardGame.Status.Alive).ToArray();

            if (winners.Length == 1)
            {
                Status = GameStatus.Ended;
            }
        }
    }

    public class Turn
    {
        public Player ActivePlayer { get; private set; }

        public bool IsNewTurn { get; set; }

        public Turn(Player activePlayer)
        {
            this.ActivePlayer = activePlayer;

            AddManaSlot();

            ActiveAllStots();

            this.ActivePlayer.TakeCard();

            IsNewTurn = true;
        }

        public void Play(Func<DomageCard[], Player[], Tuple<DomageCard, Player>> play, Player[] enemies)
        {
            var cardAndPlayer = play(ActivePlayer.GetPlayableCards().OrderBy(s => s.ManaNeededToInvoke).ToArray(), enemies.Where(s=>s.Status == Status.Alive).ToArray());

            while (cardAndPlayer != null)
            {
                cardAndPlayer.Item1.DealDomage(cardAndPlayer.Item2);

                ActivePlayer.ManaSlots.Where(s => s.Active).Take(cardAndPlayer.Item1.ManaNeededToInvoke).ToList().ForEach(s => s.Active = false);

                ActivePlayer.Hand.Remove(cardAndPlayer.Item1);

                IsNewTurn = false;

                cardAndPlayer = play(ActivePlayer.GetPlayableCards().OrderBy(s => s.ManaNeededToInvoke).ToArray(), enemies.Where(s => s.Status == Status.Alive).ToArray());
            }
        }

        private void ActiveAllStots()
        {
            foreach (var slot in ActivePlayer.ManaSlots)
            {
                slot.Active = true;
            }
        }

        private void AddManaSlot()
        {
            if (ActivePlayer.ManaSlots.Count < 10)
                ActivePlayer.ManaSlots.Add(new ManaSlot());
        }
    }
}