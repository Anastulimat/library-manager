using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDataAccess: IDisposable
    {
        IUnitOfWork BeginTransaction();

        IRepository<T> CreateRepository<T>() where T : class;
    }
}
