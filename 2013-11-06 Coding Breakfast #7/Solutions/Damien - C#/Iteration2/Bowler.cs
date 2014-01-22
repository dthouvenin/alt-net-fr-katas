using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.Iteration2
{
    public class Bowler
    {
        private List<int> _throws = new List<int>(21); 

        public void Throw(int pinsSet)
        {
            _throws.Add(pinsSet);
        }

        public int Score
        {
            get { var res = 0;
                foreach (var @throw in _throws)
                {
                    res += @throw;
                }
                return res;
            }
        }

        public int FrameNo
        {
            get {
                return (_throws.Count / 2)+1;
            }
        }
    }
}
