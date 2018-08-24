using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.Entities;
using System.Collections.Generic;

namespace ALaMarona.Domain.Businesses
{
    public interface IProductoBusiness
    {
        IList<Producto> GetAll();
        Producto GetById(long id);
        Producto Save(Producto entity);
        void Update(UpdateProductRequest updateRequest);
        void Delete(long id);
    }
}
