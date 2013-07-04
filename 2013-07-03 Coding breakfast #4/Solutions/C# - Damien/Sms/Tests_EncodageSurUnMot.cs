using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace Sms
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class Tests_Encodage_Sur_Un_Mot
    {
        [Test]
        public void Les_voyelles_sont_retirées()
        {
            string original = "vigne";
            string expected = "vgn";

            string res = SMSDecoder.EncodeWord(original);

            Assert.AreEqual(expected, res);
        }
        
        [Test]
        public void La_voyelle_de_tête_est_conservée()
        {
            string original = "été";
            string expected = "et";

            string res = SMSDecoder.EncodeWord(original);

            Assert.AreEqual(expected, res);
        }

        [Test]
        public void Les_accents_sont_retirés()
        {
            string original = "été";
            string expected = "et";

            string res = SMSDecoder.EncodeWord(original);

            Assert.AreEqual(expected, res);
        }

        [Test]
        public void Les_consonnes_doublées_sont_simplifiées()
        {
            string original = "ville";
            string expected = "vl";

            string res = SMSDecoder.EncodeWord(original);

            Assert.AreEqual(expected, res);
        }

        [Test]
        public void Les_consonnes_doublées_après_nettoyage_ne_sont_pas_simplifiées()
        {
            string original = "titre";
            string expected = "ttr";

            string res = SMSDecoder.EncodeWord(original);

            Assert.AreEqual(expected, res);
        }

        [Test]
        public void Les_majuscules_sont_réduites()
        {
            string original = "Titre";
            string expected = "ttr";

            string res = SMSDecoder.EncodeWord(original);

            Assert.AreEqual(expected, res);
        }
    }
    // ReSharper restore InconsistentNaming
}
