using ALaMarona.Core.Business;
using ALaMarona.Core.Helpers;
using ALaMarona.Core.AMapper;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.Entities;
using Eg.Core.Data;
using System.Linq;

namespace ALaMarona.Core.Businesses
{
    public class ClienteBusiness : GenericBusiness<Cliente, long>, IClienteBusiness
    {
        public ClienteBusiness(IRepository<Cliente, long> repo) : base(repo)
        {
        }

        public Cliente Save(CreateClienteRequest createRequest)
        {
            //TODO: VALIDAR QUE EL TIPO Y NRO DE DOCUMENTO NO SE REPITAN CON EL DE OTRA PERSONA
            Cliente cliente = new Cliente()
            {
                Codigo = createRequest.Codigo,
                Documento = new Documento()
                {
                    Numero = createRequest.NumeroDocumento,
                    Tipo = createRequest.TipoDocumento
                },
                Domicilio = createRequest.Domicilio.MapDireccion(),
                EMail = createRequest.EMail,
                EstadoCivil = createRequest.EstadoCivil,
                FechaNacimiento = DateTimeHelper.ParseDate(createRequest.FechaNacimiento),
                LugarNacimiento = createRequest.LugarNacimiento.MapDireccion(),
                Nombre = createRequest.MapNombre(),
                Telefono = createRequest.Telefono
            };
            return base.Save(cliente);
        }

        public void Update(UpdateClienteRequest updateRequest)
        {
            //TODO: VALIDAR QUE EL TIPO Y NRO DE DOCUMENTO NO SE REPITAN CON EL DE OTRA PERSONA
            if (repository.Contains(x => x.Codigo == updateRequest.Codigo))
            {
                Cliente cliente = repository.First(x => x.Codigo == updateRequest.Codigo);
                cliente.EMail = updateRequest.EMail;
                base.Update(cliente);
            }
            else
            {
                //TODO: HABRIA QUE DEVOLVER UNA RESPUESTA QUE CONTENGA EL MENSAJE DE ERROR
            }
        }
    }
}
