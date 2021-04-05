using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Service 
    {
        IDataAccess dataAccess;
        protected IRepository<Adherent> depotAdherents;
        protected IRepository<Exemplaire> depotExemplaires;
        protected IRepository<Ouvrage> depotOuvrages;
        protected IRepository<Pret> depotPrets;

        public Service(IDataAccess dataAccess)
        {
            this.dataAccess  = dataAccess;
            depotAdherents   = dataAccess.CreateRepository<Adherent>();
            depotExemplaires = dataAccess.CreateRepository<Exemplaire>();
            depotOuvrages    = dataAccess.CreateRepository<Ouvrage>();
            depotPrets       = dataAccess.CreateRepository<Pret>();
        }

        protected IUnitOfWork BeginTransaction()
        {
            return dataAccess.BeginTransaction();
        }
    }
}
