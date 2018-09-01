using ALaMarona.Core.Generic;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.Entities;
using ALaMarona.Domain.Generic;
using Eg.Core.Data;
using System.Linq;

namespace ALaMarona.Core.Business
{
    public class ProductoBusiness : RestrictedUpdateBusiness<Producto, long, UpdateProductRequest>, IProductoBusiness
    {
        private readonly IGenericBusiness<Color, long> colorBusiness;

        public ProductoBusiness(IRepository<Producto, long> repo, IGenericBusiness<Color, long> colorBus): base(repo)
        {
            colorBusiness = colorBus;
        }

        public override Producto Save(Producto entity)
        {
            foreach(var m in entity.MovimientosDeStock)
            {
                m.Producto = entity;
            }
            repository.Add(entity);
            return entity;
        }

        protected override Producto MapUpdateRequestToEntity(UpdateProductRequest updateRequest)
        {
            var producto = repository.FirstOrDefault(x => x.Id == updateRequest.IdProducto);
            producto.Descripcion = updateRequest.Descripcion;
            producto.Talle = updateRequest.Talle;
            producto.Color = colorBusiness.GetById(updateRequest.IdColor);
            return producto;
        }
    }
}
