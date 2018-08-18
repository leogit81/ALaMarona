using ALaMarona.Domain.Generic;
using Eg.Core;
using Eg.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ALaMarona.Core.Business
{
    public class GenericBusiness<T, TId> : IGenericBusiness<T, TId> where T: Entity<TId>
    {
        protected IRepository<T, TId> repository;

        public GenericBusiness(IRepository<T, TId> repo)
        {
            repository = repo;
        }

        public virtual void Delete(TId id)
        {
            var entity = repository.FirstOrDefault(e => e.Id.Equals(id));
            repository.Remove(entity);
        }

        public virtual IList<T> GetAll()
        {
            return repository.ToList();
        }

        public virtual T GetById(TId id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return repository.FirstOrDefault(x => id.Equals(x.Id));
        }

        public virtual T Save(T entity)
        {
            repository.Add(entity);
            return entity;
        }

        public virtual void Update(T entity)
        {
            repository.Update(entity);
        }
    }
}
