using ALaMarona.Domain.Entities;
using ALaMarona.Domain.Generic;
using System.Collections.Generic;

namespace ALaMarona.Domain.Businesses
{
    public interface IPaisBusiness: IGenericBusiness<Pais, long>
    {
        void SaveLocalidad(Localidad localidad, long idProvincia);
        IList<Pais> GetAll();
        Pais GetById(long id);
    }
}
