using ALaMarona.Domain.Entities;
using System.Collections.Generic;

namespace ALaMarona.Domain.Businesses
{
    public interface IDireccionBusiness
    {
        Direccion GetById(long direccionId);
        IList<Direccion> GetAll();
        Direccion Save(Direccion direccion);
        void Update(Direccion direccion);
        void Delete(long direccionId);
    }
}
