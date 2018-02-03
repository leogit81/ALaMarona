using Eg.Core;
using Eg.Core.Data;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ALaMarona.Core.Services
{
    public class GenericService<T, TId> : IGenericService<T, TId> where T: Entity<TId>
    {
        protected IRepository<T, TId> repository;
        protected ISessionFactory _sessionFactory;

        public GenericService(IRepository<T, TId> repo, ISessionFactory sessionFactory)
        {
            repository = repo;
            _sessionFactory = sessionFactory;
        }

        public virtual void Delete(TId id)
        {
            var entity = repository.FirstOrDefault(e => e.Id.Equals(id));
            repository.Remove(entity);
        }

        public virtual IEnumerable<T> Get()
        {
            return repository.ToList();
        }

        public virtual T Get(TId id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return repository.FirstOrDefault(x => id.Equals(x.Id));
        }

        public virtual void Save(T entity)
        {
            repository.Add(entity);
        }

        public virtual void Update(T entity)
        {
            repository.Update(entity);
        }
    }
}
