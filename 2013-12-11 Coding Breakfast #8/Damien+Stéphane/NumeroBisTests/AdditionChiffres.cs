using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumeroBisTests
{
    [TestClass]
    public class AdditionChiffres: TestsBase
    {
        [TestMethod]
        public void II_Vaut_Deux()
        {
            AssertEquals(2, "II");
        }

        [TestMethod]
        public void III_Vaut_Troix()
        {
            AssertEquals(3, "III");
        }

        [TestMethod]
        public void VI_Vaut_Six()
        {
            AssertEquals(6, "VI");
        }

        [TestMethod]
        public void MCCCLXXVI_Vaut_Mille_Trois_Cent_Soixante_Seize()
        {
            AssertEquals(1376, "MCCCLXXVI");
        }
    }
}
