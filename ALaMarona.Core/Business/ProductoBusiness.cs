using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Entities;
using Eg.Core.Data;

namespace ALaMarona.Core.Business
{
    public class ProductoBusiness : GenericBusiness<Producto, long>, IProductoBusiness
    {
        public ProductoBusiness(IRepository<Producto, long> repo) : base(repo)
        {
        }

        public override Producto Save(Producto entity)
        {
            foreach(var m in entity.MovimientosDeStock)
            {
                m.Producto = entity;
            }
            return base.Save(entity);
        }

        public override void Update(Producto entity)
        {
            foreach (var m in entity.MovimientosDeStock)
            {
                m.Producto = entity;
            }
            base.Update(entity);
        }
    }
}
