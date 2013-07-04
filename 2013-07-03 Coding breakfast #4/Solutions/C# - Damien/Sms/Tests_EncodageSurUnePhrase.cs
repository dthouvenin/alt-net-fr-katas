using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace Sms
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    class Tests_Encodage_Sur_Une_Phrase
    {
        [Test]
        public void Tous_les_mots_sont_reperes()
        {
            string original = "et ça c'est cool";
            var mots = new List<string>();

            SMSDecoder.ExtractAllWords(original, mots.Add);

            Assert.AreEqual(5, mots.Count);
            Assert.AreEqual("et", mots[0]);
            Assert.AreEqual("ça", mots[1]);
            Assert.AreEqual("c", mots[2]);
            Assert.AreEqual("est", mots[3]);
            Assert.AreEqual("cool", mots[4]);
        }

        [Test]
        public void La_ponctuation_est_ignorée()
        {
            string original = "exemple: l'apostrophe est ignorée";
            var mots = new List<string>();

            SMSDecoder.ExtractAllWords(original, mots.Add);

            Assert.AreEqual(5, mots.Count);
            Assert.AreEqual("exemple", mots[0]);
            Assert.AreEqual("l", mots[1]);
            Assert.AreEqual("apostrophe", mots[2]);
            Assert.AreEqual("est", mots[3]);
            Assert.AreEqual("ignorée", mots[4]);
        }

        [Test]
        public void Les_Mots_Sont_Nettoyes()
        {
            string original = "Le titre du livre est Le portrait de Dorian Gray et ça c'est cool";
            string expected = "l ttr d lvr est l prtrt d drn gr et c c est cl";

            string res = SMSDecoder.EncodeSentence(original);

            Assert.AreEqual(expected, res);            
        }
    }
    // ReSharper restore InconsistentNaming
}
