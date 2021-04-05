using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceOuvrages : Service
    {
        public ServiceOuvrages(IDataAccess factory) : base(factory) { }

        public List<Ouvrage> ObtenirListe()
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                List<Ouvrage> liste = depotOuvrages.Query().ToList();
                uow.Commit();
                return liste;
            }
        }

        public void Ajouter(Ouvrage ouvrage)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                depotOuvrages.Create(ouvrage);
                uow.Commit();
            }
        }

        public void Modifier(int idOuvrage)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Ouvrage ouvrage = depotOuvrages.Read(idOuvrage);
                if (ouvrage == null)
                {
                    throw new Exception("Impossible de modifier, l'ouvrage n'a pas été trouvé !");
                }
                depotOuvrages.Update(ouvrage);
                uow.Commit();
            }
        }

        public void Supprimer(int idOuvrage)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Ouvrage ouvrage = depotOuvrages.Read(idOuvrage);
                if (ouvrage == null)
                {
                    throw new Exception("Impossible de supprimer, l'ouvrage n'a pas été trouvé !");
                }
                depotOuvrages.Delete(ouvrage);
                uow.Commit();
            }
        }
    }
}
