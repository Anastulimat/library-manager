using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IRepository<T>
    {
        void Create(T entity);

        T Read(int id);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Query();
    }

}
