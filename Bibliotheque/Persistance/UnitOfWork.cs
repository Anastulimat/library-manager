using NHibernate;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        ISession session;
        ITransaction trans;

        public UnitOfWork(ISession session)
        {
            trans = session.BeginTransaction();
        }

        public void Commit()
        {
            trans.Commit();
        }

        public void Dispose()
        {
            trans.Dispose(); // rollback the transaction if it was not committed
        }
    }
}
