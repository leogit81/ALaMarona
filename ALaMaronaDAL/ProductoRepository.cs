using ALaMarona.Domain.Entities;
using Eg.Core;
using Eg.Core.Data.Impl;
using NHibernate;
using System.Collections.Generic;

namespace ALaMaronaDAL
{
    public class ProductoRepository: NHibernateRepository<Entity<long>, long>
    {
        public ProductoRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {

        }

        public Producto GetById(long id)
        {
            return null;
        }

        public IList<Producto> GetAll()
        {
            return session.CreateCriteria<Producto>().List<Producto>();
        }
    }
}
