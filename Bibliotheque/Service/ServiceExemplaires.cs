using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceExemplaires : Service
    {
        public ServiceExemplaires(IDataAccess factory) : base(factory) { }

        public List<Exemplaire> ObtenirListeParOuvrage(int id_ouvrage)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                List<Exemplaire> liste = depotExemplaires.Query().Where(ex => ex.Ouvrage.Id == id_ouvrage).ToList();
                uow.Commit();
                return liste;
            }
        }

        public void Ajouter(Exemplaire exemplaire)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                depotExemplaires.Create(exemplaire);
                uow.Commit();
            }
        }

        public void Modifier(int idExemplaire)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Exemplaire exemplaire = depotExemplaires.Read(idExemplaire);

                if (exemplaire == null)
                {
                    throw new Exception("Impossible de modifier, l'exemplaire n'a pas été trouvé !");
                }
                depotExemplaires.Update(exemplaire);
                uow.Commit();
            }
        }

        public void Supprimer(int idExemplaire)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Exemplaire exemplaire = depotExemplaires.Read(idExemplaire);

                if (exemplaire == null)
                {
                    throw new Exception("Impossible de supprimer, l'exemplaire n'a pas été trouvé !");
                }
                depotExemplaires.Delete(exemplaire);
                uow.Commit();
            }
        }
    }
}
