using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.Iteration3
{
    public class Bowler
    {
        private List<int> _throws = new List<int>(21); 

        public void Throw(int pinsSet)
        {
            _throws.Add(pinsSet);
        }

        public int? Score
        {
            get
            {
                int? result = null;
                for (var frameNo = 1; frameNo <= FrameNo; frameNo++ )
                {
                    var firstThrow = (frameNo-1)*2;
                    var secondThrow = firstThrow + 1;

                    if (firstThrow >= _throws.Count)
                        break;
                    if (secondThrow == _throws.Count)  // open frame
                        return null;
                    var frameScore = _throws[firstThrow] + _throws[secondThrow];
                    result = frameScore + (result??0);
                    if (10 == frameScore) // spare
                    {
                        if (++secondThrow < _throws.Count)
                            result = _throws[secondThrow] + (result??0);
                        else
                            return null;
                    }
                }
                return result;
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
