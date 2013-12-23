using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumerobisTest
{
    [TestClass]
    public class CasFoireux : TestsBase
    {
        [TestMethod, ExpectedException(typeof(ArgumentException), "Ce texte n'est pas un nombre romain valide et aurait dû lever une exception", AllowDerivedTypes = true)]
        public void IL_n_est_pas_valable()
        {
            AssertEquals(49, "IL");
        }


        [TestMethod, ExpectedException(typeof(ArgumentException), "Ce texte n'est pas un nombre romain valide et aurait dû lever une exception", AllowDerivedTypes = true)]
        public void IIX_n_est_pas_valable()
        {
            AssertEquals(10, "IIX");
        }


        [TestMethod, ExpectedException(typeof(ArgumentException), "Ce texte n'est pas un nombre romain valide et aurait dû lever une exception", AllowDerivedTypes = true)]
        public void IXIX_n_est_pas_valable()
        {
            AssertEquals(18, "IXIX");
        }


        [TestMethod, ExpectedException(typeof(ArgumentException), "Ce texte n'est pas un nombre romain valide et aurait dû lever une exception", AllowDerivedTypes = true)]
        public void XXXX_n_est_pas_valable()
        {
            AssertEquals(40, "XXXX");
        }
        [TestMethod, ExpectedException(typeof(ArgumentException), "Ce texte n'est pas un nombre romain valide et aurait dû lever une exception", AllowDerivedTypes = true)]
        public void VD_n_est_pas_valable()
        {
            AssertEquals(45, "VD");
        }
        [TestMethod, ExpectedException(typeof(ArgumentException), "Ce texte n'est pas un nombre romain valide et aurait dû lever une exception", AllowDerivedTypes = true)]
        public void IXIV_n_est_pas_valable()
        {
            AssertEquals(13, "IXIV");
        }
        [TestMethod, ExpectedException(typeof(ArgumentException), "Ce texte n'est pas un nombre romain valide et aurait dû lever une exception", AllowDerivedTypes = true)]
        public void CMC_n_est_pas_valable()
        {
            AssertEquals(1000, "CMC");
        }
    }
}
