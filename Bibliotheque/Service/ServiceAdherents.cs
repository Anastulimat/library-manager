 using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceAdherents : Service
    {
        public ServiceAdherents(IDataAccess factory) : base(factory) { }
 

        public List<Adherent> ObtenirListe()
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                List<Adherent> liste = depotAdherents.Query().ToList();
                uow.Commit();
                return liste;
            }
        }

        public void Ajouter(Adherent adherent)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                depotAdherents.Create(adherent);
                uow.Commit();
            }
        }

        public void Modifier(int idAdherent)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Adherent adherent = depotAdherents.Read(idAdherent);
                if(adherent == null)
                {
                    throw new Exception("Impossible de modifier, l'adherent n'a pas été trouvé !");
                }
                depotAdherents.Update(adherent);
                uow.Commit();
            }
        }

        public void Supprimer(int idAdherent)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Adherent adherent = depotAdherents.Read(idAdherent);
                if (adherent == null)
                {
                    throw new Exception("Impossible de supprimer, l'adherent n'a pas été trouvé !");
                }
                depotAdherents.Delete(adherent);
                uow.Commit();
            }
        }
    }
}
