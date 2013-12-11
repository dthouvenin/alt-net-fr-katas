using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumeroBisTests
{
    [TestClass]
    public class Soustraction: TestsBase
    {
        [TestMethod]
        public void IX_Vaut_Neuf()
        {
            AssertEquals(9, "IX");
        }

        [TestMethod]
        public void XL_Vaut_Quarante()
        {
            AssertEquals(40, "XL");
        }

        [TestMethod]
        public void MCMLXXIV_Vaut_Mille_Neuf_Cent_Soixante_Quatorze()
        {
            AssertEquals(1974, "MCMLXXIV");
        }

    }
}
