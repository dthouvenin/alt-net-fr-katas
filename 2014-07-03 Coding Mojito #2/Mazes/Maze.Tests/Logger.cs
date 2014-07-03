using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mazes.Core;

namespace Mazes.Tests
{
    class Event
    {
        public Event(string eventName)
        {
            Timestamp = DateTime.Now.Ticks;
            EventName = eventName;
        }
        public readonly long Timestamp;
        public readonly string EventName;
        public virtual string AsText()
        {
            return EventName;
        }
    }
    class MovedEvent : Event
    {
        public MovedEvent(Position pos)
            : base("MouseHasMoved")
        {
            Position = pos;
        }

        public readonly Position Position;

        public override string AsText()
        {
            return string.Format("{0} [{1}, {2}]", EventName, Position.X, Position.Y);
        }
    }

    class TurnedEvent : Event
    {
        public TurnedEvent(Direction direction)
            : base("MouseHasTurned")
        {
            Direction = direction;
        }

        public readonly Direction Direction;

        public override string AsText()
        {
            return string.Format("{0} {1}", EventName, Direction);
        }
    }
    
    class LogWatcher : IMazeWatcher
    {
        public readonly Stack<Event> Events = new Stack<Event>();

        public string Dump()
        {
            var output = new StringBuilder();
            while (Events.Count > 0)
            {
                output.AppendLine(Events.Pop().AsText());
            }
            return output.ToString();
        }

        public void MouseWantsToMove()
        {
            Events.Push(new Event("MouseWantsToMove"));
        }

        public void MouseHasMoved(Position newPosition)
        {
            Events.Push(new MovedEvent(newPosition));
        }

        public void MouseHasTurned(Direction newDirection)
        {
            Events.Push(new TurnedEvent(newDirection));
        }

        public void MouseHasExitedMaze()
        {
            Events.Push(new Event("MouseHasExitedMaze"));
        }

        public void MazeHasBeenBuilt(int with, int height)
        {
        }

        public void YouHaveBeenUnsubscribed()
        {
        }

    }

}
