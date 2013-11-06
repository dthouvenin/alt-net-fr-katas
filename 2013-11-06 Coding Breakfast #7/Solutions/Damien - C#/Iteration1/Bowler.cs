using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.Iteration1
{
    public class Bowler
    {
        private int _score;
        
        public void Throw(int pinsSet)
        {
            _score += pinsSet;
        }

        public int Score
        {
            get { return _score; }
        }
    }
}
