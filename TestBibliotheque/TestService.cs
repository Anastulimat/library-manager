using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using Domaine;
using Persistance;
using System.Collections.Generic;
using NHibernate;

namespace TestBibliotheque
{
    [TestClass]
    public class TestService
    {
        ISessionFactory sessionFactory;
        IDataAccess dataAccess;
        ServicePrets servicePrets;
        ServiceAdherents serviceAdherents;
        ServiceOuvrages serviceOuvrages;
        ServiceExemplaires serviceExemplaires;

        Adherent adherent;
        Ouvrage ouvrage;
        Exemplaire exemplaire1, exemplaire2;

        [TestInitialize]
        public void SetUp()
        {
            sessionFactory = ORM<Adherent>.CreateSessionFactory(true);
            dataAccess = new DataAccess(sessionFactory);
            servicePrets = new ServicePrets(dataAccess);
            serviceAdherents = new ServiceAdherents(dataAccess);
            serviceOuvrages = new ServiceOuvrages(dataAccess);
            serviceExemplaires = new ServiceExemplaires(dataAccess);
            CreateFixtures();
            PopulateDatabase();
        }

        [TestCleanup]
        public void TearDown()
        {
            dataAccess.Dispose();
            sessionFactory.Dispose();
        }

        void CreateFixtures()
        {
            adherent = new Adherent { Nom = "Mario Rossi" };
            ouvrage = new Ouvrage { Titre = "Il grande Gatsby", Auteur = "F. S. Fitzgerald" };
            exemplaire1 = new Exemplaire { Ouvrage = ouvrage, Etat = "Nuovo" };
            exemplaire2 = new Exemplaire { Ouvrage = ouvrage, Etat = "Usato" };
        }

        void PopulateDatabase()
        {
            using (ISession session = sessionFactory.OpenSession())
            using (ITransaction uow = session.BeginTransaction())
            {
                session.Save(adherent);
                session.Save(ouvrage);
                session.Save(exemplaire1);
                session.Save(exemplaire2);
                uow.Commit();
            }
        }

        # region Test Pret

        [TestMethod]
        public void EmpruntSucces()
        {
            servicePrets.TraiterEmprunt(adherent.Id, exemplaire1.Id);
            AssertPret(adherent.Id, exemplaire1.Id, true);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EmpruntEchec()
        {
            servicePrets.TraiterEmprunt(adherent.Id, 3);
        }

        [TestMethod]
        public void RetourSucces()
        {
            servicePrets.TraiterEmprunt(adherent.Id, exemplaire1.Id);
            servicePrets.TraiterRetour(exemplaire1.Id);
            AssertPret(adherent.Id, exemplaire1.Id, false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RetourEchec()
        {
            servicePrets.TraiterRetour(exemplaire1.Id);
        }

        void AssertPret(int id_adherent, int id_exemplaire, bool estEnCours)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                Adherent ad = session.Get<Adherent>(id_adherent);
                Exemplaire ex = session.Get<Exemplaire>(id_exemplaire);
                Assert.AreEqual(ex.Id, ad.Prets[0].Exemplaire.Id);
                if (estEnCours)
                    Assert.AreEqual(ad.Id, ex.Adherent.Id);
                else
                    Assert.IsNull(ex.Adherent);
            }
        }

        #endregion


        #region Test Adherent


        void AssertEqualAdherent(String nom)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                List<Adherent> adherents = serviceAdherents.ObtenirListe();
                Assert.AreEqual(adherents[adherents.Count - 1].Nom, nom);
            }
        }

        void AssertNotEqualAdherent(String nom)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                List<Adherent> adherents = serviceAdherents.ObtenirListe();
                Assert.AreNotEqual(adherents[adherents.Count - 1].Nom, nom);
            }
        }

        void AssertExistAdherent(Adherent adherent)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                List<Adherent> adherents = serviceAdherents.ObtenirListe();
                Assert.IsTrue(adherents.Contains(adherent));
            }
        }

        void AssertNotExistAdherent(Adherent adherent)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                List<Adherent> adherents = serviceAdherents.ObtenirListe();
                Assert.IsFalse(adherents.Contains(adherent));
            }
        }

        [TestMethod]
        public void AdherentCRUD()
        {
            Adherent adherent = new Adherent { Nom = "Anas TULIMAT" };

            //Ajouter adherent
            serviceAdherents.Ajouter(adherent);
            AssertEqualAdherent(adherent.Nom);

            //Modifier adherent
            adherent.Nom = "Guillaume DEMEYERE";
            serviceAdherents.Modifier(adherent.Id);
            AssertNotEqualAdherent("Anas TULIMAT");
            AssertEqualAdherent(adherent.Nom);

            //Suppresion adherent
            serviceAdherents.Supprimer(adherent.Id);
            AssertNotExistAdherent(adherent);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ModifierAdherentEchec()
        {
            Adherent adherent = new Adherent { Nom = "Nom" };
            serviceAdherents.Modifier(adherent.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeleteAdherentEchec()
        {
            Adherent adherent = new Adherent { Nom = "Nom" };
            serviceAdherents.Supprimer(adherent.Id);
        }

        #endregion


        #region Test Ouvrage

        void AssertEqualOuvrage(String titre, String auteur)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                List<Ouvrage> ouvrages = serviceOuvrages.ObtenirListe();
                Assert.AreEqual(ouvrages[ouvrages.Count - 1].Titre, titre);
                Assert.AreEqual(ouvrages[ouvrages.Count - 1].Auteur, auteur);
            }
        }

        void AssertNotEqualOuvrage(String titre, String auteur)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                List<Ouvrage> ouvrages = serviceOuvrages.ObtenirListe();
                Assert.AreNotEqual(ouvrages[ouvrages.Count - 1].Titre, titre);
                Assert.AreNotEqual(ouvrages[ouvrages.Count - 1].Auteur, auteur);
            }
        }

        void AssertExistOuvrage(Ouvrage ouvrage)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                List<Ouvrage> ouvrages = serviceOuvrages.ObtenirListe();
                Assert.IsTrue(ouvrages.Contains(ouvrage));
            }
        }

        void AssertNotExistOuvrage(Ouvrage ouvrage)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                List<Ouvrage> ouvrages = serviceOuvrages.ObtenirListe();
                Assert.IsFalse(ouvrages.Contains(ouvrage));
            }
        }

        [TestMethod]
        public void OuvrageCRUD()
        {
            Ouvrage ouvrage = new Ouvrage { Titre = "Paris au 20ème siècle", Auteur = "Jules Vernes" };

            //Ajouter ouvrage
            serviceOuvrages.Ajouter(ouvrage);
            AssertEqualOuvrage(ouvrage.Titre, ouvrage.Auteur);

            //Modifier ouvrage
            ouvrage.Titre = "La vie devant soi";
            ouvrage.Auteur = "Romain Gary";
            serviceOuvrages.Modifier(ouvrage.Id);
            AssertNotEqualOuvrage("Paris au 20ème siècle", "Jules Vernes");
            AssertEqualOuvrage(ouvrage.Titre, ouvrage.Auteur);

            //Suppresion ouvrage
            serviceOuvrages.Supprimer(ouvrage.Id);
            AssertNotExistOuvrage(ouvrage);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ModifierOuvrageEchec()
        {
            Ouvrage ouvrage = new Ouvrage { Titre = "OuvrageTitre", Auteur = "OuvrageAuteur" };
            serviceOuvrages.Modifier(ouvrage.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeleteOuvrageEchec()
        {
            Ouvrage ouvrage = new Ouvrage { Titre = "OuvrageTitre", Auteur = "OuvrageAuteur" };
            serviceOuvrages.Supprimer(ouvrage.Id);
        }

        #endregion

        #region Test Exemplaire

        void AssertEqualExemplaire(int id_ouvrage, int id_exemplaire)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                List<Exemplaire> exemplaires = serviceExemplaires.ObtenirListeParOuvrage(id_ouvrage);
                Assert.AreEqual(exemplaires[exemplaires.Count - 1].Id, id_exemplaire);
            }
        }

        void AssertNotEqualExemplaire(int id_ouvrage, int id_exemplaire)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                List<Exemplaire> exemplaires = serviceExemplaires.ObtenirListeParOuvrage(id_ouvrage);
                Assert.AreNotEqual(exemplaires[exemplaires.Count - 1].Id, id_exemplaire);
            }
        }

        [TestMethod]
        public void AjouterExemplaire()
        {
            Ouvrage ouvrage = new Ouvrage { Auteur = "AuteurOuvrage", Titre = "TitreOuvrage" };
            Exemplaire exemplaire = new Exemplaire { Ouvrage = ouvrage, Etat = "N" };
            serviceExemplaires.Ajouter(exemplaire);
            AssertExemplaire(ouvrage.Id, exemplaire.Id);
        }

        [TestMethod]
        public void ModifierExemplaire()
        {
            Ouvrage ouvrage = new Ouvrage { Auteur = "AuteurOuvrage", Titre = "TitreOuvrage" };
            Exemplaire exemplaire = new Exemplaire { Ouvrage = ouvrage, Etat = "N" };
            serviceExemplaires.Ajouter(exemplaire);
            exemplaire.Etat = "O";
            serviceExemplaires.Modifier(exemplaire.Id);
            AssertModifierExemplaire(ouvrage.Id);
        }

        [TestMethod]
        public void SupprimerExemplaire()
        {
            Ouvrage ouvrage = new Ouvrage { Auteur = "AuteurOuvrage", Titre = "TitreOuvrage" };
            Exemplaire exemplaire = new Exemplaire { Ouvrage = ouvrage, Etat = "N" };
            serviceExemplaires.Ajouter(exemplaire);
            serviceExemplaires.Supprimer(exemplaire.Id);
            AssertSupprimerExemplaire(ouvrage.Id, exemplaire);
        }

        void AssertExemplaire(int id_ouvrage, int id_exemplaire)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                List<Exemplaire> exemplaires = serviceExemplaires.ObtenirListeParOuvrage(id_ouvrage);
                Assert.AreEqual(exemplaires[exemplaires.Count - 1].Id, id_exemplaire);
            }
        }

        void AssertModifierExemplaire(int id_ouvrage)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                List<Exemplaire> exemplaires = serviceExemplaires.ObtenirListeParOuvrage(id_ouvrage);
                Assert.AreEqual(exemplaires[exemplaires.Count - 1].Etat, "O");
            }
        }

        void AssertSupprimerExemplaire(int id_ouvrage, Exemplaire exemplaire)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                List<Exemplaire> exemplaires = serviceExemplaires.ObtenirListeParOuvrage(id_ouvrage);
                Assert.IsFalse(exemplaires.Contains(exemplaire));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ModifierExemplaireEchec()
        {
            Ouvrage ouvrage = new Ouvrage { Auteur = "AuteurOuvrage2", Titre = "TitreOuvrage2" };
            Exemplaire exemplaire = new Exemplaire { Ouvrage = ouvrage, Etat = "N" };
            serviceExemplaires.Modifier(exemplaire.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeleteExemplaireEchec()
        {
            Ouvrage ouvrage = new Ouvrage { Auteur = "AuteurOuvrage2", Titre = "TitreOuvrage2" };
            Exemplaire exemplaire = new Exemplaire { Ouvrage = ouvrage, Etat = "N" };
            serviceExemplaires.Supprimer(exemplaire.Id);
        }
        #endregion
    }
}
