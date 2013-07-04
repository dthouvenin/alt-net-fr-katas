using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace Sms
{
    [TestFixture]
    public class Tests_CompletsAvecDico
    {
        private SMSDecoder _decoder;


        [FixtureSetUp]
        public void Setup()
        {
            _decoder = new SMSDecoder("dictionnaire.txt");
        }

        [Test]
        public void ExempleSimple()
        {
            string original = "l frctnmnt";
            string expected = "(l la laie le lia lie lieu lieue loi loua loue lu lue lui) fractionnement";

            var res = _decoder.DecodeSentence(original);

            Assert.AreEqual(expected, res);
        }

        [Test]
        public void ExempleRiche()
        {
            string original = "dns ct exmpl il y a bcp d mts ambgs";
            string expected = "(danois danoise dans dansa danse dense donnais donnes donneuse dons douanes doyennes doyens dunes) "
                +"(cet cette cita cite coite cota cote coteau cotte couette couteau coyote ct cuit cuite cuti) "
                +"exemple il (y youyou) (a ai aie au) beaucoup (de dieu do du due duo) "
                +"(mates matois matoise mats mets mettais mettes meutes miettes mites miteuse mitose moites motos mots mottes mouettes muets muettes mutais mutes) "
                +"(ambages ambigus)";

            var res = _decoder.DecodeSentence(original);

            Assert.AreEqual(expected, res);
        }        
    }
}
