using ALaMarona.Domain.Entities;
using Eg.Core.Data;
using Eg.Core.Data.Impl;
using NHibernate;
using System.Linq;

namespace ALaMarona.Core.Services
{
    public class MovimientoStockService : GenericService<MovimientoStock, long>, IGenericService<MovimientoStock, long>
    {
        protected IRepository<Producto, long> _productoRepository;

        public MovimientoStockService(IRepository<MovimientoStock, long> repo, ISessionFactory sessionFactory) : base(repo, sessionFactory)
        {
            _productoRepository = new NHibernateRepository<Producto, long>(_sessionFactory);
        }

        public override void Save(MovimientoStock entity)
        {
            var producto = _productoRepository.Where(x => x.Id == entity.Id).FirstOrDefault();
            entity.Producto = producto;
            base.Save(entity);
        }
    }
}
