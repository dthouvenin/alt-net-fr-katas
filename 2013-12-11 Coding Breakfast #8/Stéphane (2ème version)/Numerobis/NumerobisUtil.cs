using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerobis
{
    class NumerobisUtil
    {
        public enum RomainNumbers
        {
            I = 1,
            V = 5,
            X = 10,
            L = 50,
            C = 100,
            D = 500,
            M = 1000
        }
        
        public enum RomainFormat
        {
            A = 1,
            AA = 2,
            AAA = 3,
            AB = 4,
            B = 5,
            BA = 6,
            BAA = 7,
            BAAA = 8,
            AE = 9,
        }

        public enum RomainSequenceA
        {
            I = 1,
            X = 2,
            C = 3,
            M = 4
        }

        public enum RomainSequenceB
        {
            V = 1,
            L = 2,
            D = 3
        }
    }
}
