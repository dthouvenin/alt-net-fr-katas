using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumeroBisTests
{
    [TestClass]
    public class EcrituresValides : TestsBase
    {
        [TestMethod]
        public void IL_n_est_pas_valable()
        {
            AssertIsInvalid("IL");
        }

        [TestMethod]
        public void IIX_n_est_pas_valable()
        {
            AssertIsInvalid("IIX");
        }

        [TestMethod]
        public void IXIX_n_est_pas_valable()
        {
            AssertIsInvalid("IXIX");
        }

        [TestMethod]
        public void XXXX_n_est_pas_valable()
        {
            AssertIsInvalid("XXXX");
        }

        [TestMethod]
        public void VD_n_est_pas_valable()
        {
            AssertIsInvalid("VD");
        }

        [TestMethod]
        public void IXIV_n_est_pas_valable()
        {
            AssertIsInvalid("IXIV");
        }
    }
}
