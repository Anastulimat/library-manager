using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domaine;

namespace TestBibliotheque
{
    [TestClass]
    public class TestDomaine
    {
        Adherent adherent;
        Ouvrage ouvrage;
        Exemplaire exemplaire1, exemplaire2;

        [TestInitialize]
        public void SetUp()
        {
            adherent = new Adherent { Id = 1, Nom = "Mario Rossi" };
            ouvrage = new Ouvrage { Id = 1, Titre = "Il grande Gatsby", Auteur = "F. S. Fitzgerald" };
            exemplaire1 = new Exemplaire { Id = 1, Ouvrage = ouvrage, Etat = "Nuovo" };
            exemplaire2 = new Exemplaire { Id = 2, Ouvrage = ouvrage, Etat = "Usato" };
        }

        [TestMethod]
        public void EmpruntSucces()
        {
            Pret pret = adherent.Emprunte(exemplaire1);

            Assert.IsTrue(adherent.Prets.Contains(pret));
            Assert.IsFalse(pret.EstTermine());
            Assert.IsFalse(exemplaire1.EstDisponible());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EmpruntEchec()
        {
            adherent.Emprunte(exemplaire1);
            adherent.Emprunte(exemplaire1);
        }

        [TestMethod]
        public void RetourSucces()
        {
            Pret pret = adherent.Emprunte(exemplaire1);
            adherent.Retourne(exemplaire1);

            Assert.IsTrue(adherent.Prets.Contains(pret));
            Assert.IsTrue(pret.EstTermine());
            Assert.IsTrue(exemplaire1.EstDisponible());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RetourEchec()
        {
            Pret pret = adherent.Emprunte(exemplaire1);
            adherent.Retourne(exemplaire2);
        }
    }
}
