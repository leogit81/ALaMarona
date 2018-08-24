using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.Entities;
using ALaMarona.Domain.Generic;
using Eg.Core.Data;
using System.Collections.Generic;
using System.Linq;

namespace ALaMarona.Core.Business
{
    public class ProductoBusiness : IProductoBusiness
    {
        protected IRepository<Producto, long> repository;
        private readonly IGenericBusiness<Color, long> colorBusiness;

        public ProductoBusiness(IRepository<Producto, long> repo, IGenericBusiness<Color, long> colorBus)
        {
            repository = repo;
            colorBusiness = colorBus;
        }

        public void Delete(long id)
        {
            var entity = repository.FirstOrDefault(e => e.Id.Equals(id));
            repository.Remove(entity);
        }

        public IList<Producto> GetAll()
        {
            return repository.ToList();
        }

        public Producto GetById(long id)
        {
            return repository.FirstOrDefault(x => id.Equals(x.Id));
        }

        public Producto Save(Producto entity)
        {
            foreach(var m in entity.MovimientosDeStock)
            {
                m.Producto = entity;
            }
            repository.Add(entity);
            return entity;
        }

        public void Update(UpdateProductRequest updateRequest)
        {
            var producto = repository.FirstOrDefault(x => x.Id == updateRequest.IdProducto);
            producto.Descripcion = updateRequest.Descripcion;
            producto.Talle = updateRequest.Talle;
            producto.Color = colorBusiness.GetById(updateRequest.IdColor);
            repository.Update(producto);
        }
    }
}
