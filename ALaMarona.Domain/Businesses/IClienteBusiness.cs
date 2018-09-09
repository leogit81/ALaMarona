using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.Entities;
using ALaMarona.Domain.Generic;

namespace ALaMarona.Domain.Businesses
{
    public interface IClienteBusiness: IGenericBusiness<Cliente, long>
    {
        Cliente Save(CreateClienteRequest entity);
        void Update(UpdateClienteRequest entity);
    }
}
