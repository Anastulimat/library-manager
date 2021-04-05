using NHibernate;
using NHibernate.Linq;
using Service;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Persistance
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public void Create(T entity)
        {
            session.Save(entity);
        }

        public T Read(int id)
        {
            return session.Get<T>(id);
        }

        public void Update(T entity)
        {
            session.Update(entity);
        }

        public void Delete(T entity)
        {
            session.Delete(entity);
        }

        public IQueryable<T> Query()
        {
            return session.Query<T>();
        }
    }
}