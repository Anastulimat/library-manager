using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServicePrets : Service
    {
        public ServicePrets(IDataAccess factory) : base(factory) { }

        public List<Pret> ObtenirListeParAdherent(int id_adherent)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                List<Pret> liste = depotPrets.Query().Where(p => p.Exemplaire.Adherent.Id == id_adherent).ToList();
                foreach(Pret pret in liste)
                {
                    Console.WriteLine(pret);
                }
                uow.Commit();
                return liste;
            }
        }

        public void TraiterEmprunt(int idAdherent, int idExemplaire)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Adherent adherent = depotAdherents.Read(idAdherent);
                Exemplaire exemplaire = depotExemplaires.Read(idExemplaire);

                if(exemplaire == null)
                {
                    throw new Exception("Vous ne pouvez pas emprunter cela !");
                }

                Pret pret = adherent.Emprunte(exemplaire);
                depotAdherents.Update(adherent);
                depotPrets.Create(pret);

                uow.Commit();
            }
        }

        public void TraiterRetour(int idExemplaire)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Exemplaire exemplaire = depotExemplaires.Read(idExemplaire);
                if(exemplaire.Adherent == null)
                {
                    throw new Exception("Exemplaire non emprunté !");
                }

                Adherent adherent = exemplaire.Adherent;
                adherent.Retourne(exemplaire);

                depotAdherents.Update(adherent);
                depotExemplaires.Update(exemplaire);

                uow.Commit();
            }
        }
    }
}
