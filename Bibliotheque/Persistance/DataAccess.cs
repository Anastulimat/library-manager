using NHibernate;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class DataAccess : IDataAccess
    {
        ISession session;

        public DataAccess(ISessionFactory factory)
        {
            session = factory.OpenSession();
        }

        public IUnitOfWork BeginTransaction()
        {
            return new UnitOfWork(session);
        }

        public IRepository<T> CreateRepository<T>() where T : class
        {
            return new Repository<T>(session);
        }

        public void Dispose()
        {
            session.Dispose();
        }
    }
}
