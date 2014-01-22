using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumerobisTest
{
    [TestClass]
    public class SoustractionChiffres : TestsBase
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
