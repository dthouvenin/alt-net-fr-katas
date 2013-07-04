using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace Sms
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class Test_Dico
    {
        [Test]
        public void Quand_une_clé_n_existe_pas_le_resultat_c_est_la_clé()
        {
            var dico = new Dico();
            var clé = "clé";

            var res = dico[clé];

            Assert.AreEqual(1, res.Count);
            Assert.AreEqual(clé, res[0]);
        }

        [Test]
        public void Quand_j_ajoute_un_mot_je_le_retrouve()
        {
            var dico = new Dico();
            var clé = "clé";
            var mot = "mot";

            dico.Add(clé, mot);
            var res = dico[clé];

            Assert.AreEqual(1, res.Count);
            Assert.AreEqual(mot, res[0]);            
        }

        [Test]
        public void Quand_j_ajoute_cinq_mots_je_les_retrouve()
        {
            var dico = new Dico();
            var clé = "clé";
            var mot = "mot";

            dico.Add(clé, mot + "1");
            dico.Add(clé, mot + "2");
            dico.Add(clé, mot + "3");
            dico.Add(clé, mot + "4");
            dico.Add(clé, mot + "5");
            var res = dico[clé];

            Assert.AreEqual(5, res.Count);
            Assert.AreEqual(mot + "1", res[0]);
            Assert.AreEqual(mot + "2", res[1]);
            Assert.AreEqual(mot + "3", res[2]);
            Assert.AreEqual(mot + "4", res[3]);
            Assert.AreEqual(mot + "5", res[4]);            
            
        }

        [Test]
        public void Quand_j_ajoute_deux_fois_le_même_mot_il_ne_ressort_qu_une_fois()
        {
            var dico = new Dico();
            var clé = "clé";
            var mot = "mot";

            dico.Add(clé, mot);
            dico.Add(clé, mot);
            var res = dico[clé];

            Assert.AreEqual(1, res.Count);
            Assert.AreEqual(mot, res[0]);
        }

        [Test]
        [ExpectedArgumentNullException]
        public void Je_ne_peux_pas_ajouter_un_mot_vide()
        {
            var dico = new Dico();
            var clé = "clé";

            dico.Add(clé, string.Empty);

            Assert.Fail("Je n'aurai pas dû pouvoir ajouter un mot vide");
        }

        [Test]
        [ExpectedArgumentNullException]
        public void Je_ne_peux_pas_ajouter_un_mot_null()
        {
            var dico = new Dico();
            var clé = "clé";

            dico.Add(clé, null);

            Assert.Fail("Je n'aurai pas dû pouvoir ajouter un mot null");
        }

        [Test]
        [ExpectedArgumentNullException]
        public void Je_ne_peux_pas_ajouter_une_clé_vide()
        {
            var dico = new Dico();
            var mot = "mot";

            dico.Add(string.Empty, mot);

            Assert.Fail("Je n'aurai pas dû pouvoir ajouter une clé vide");
        }

        [Test]
        [ExpectedArgumentNullException]
        public void Je_ne_peux_pas_ajouter_une_cle_nulle()
        {
            var dico = new Dico();
            var mot = "mot";

            dico.Add(null, mot);

            Assert.Fail("Je n'aurai pas dû pouvoir ajouter une clé nulle");
        }

    }
    // ReSharper restore InconsistentNaming
}
