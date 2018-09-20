using ALaMarona.Core.Business;
using ALaMarona.Core.Helpers;
using ALaMarona.Core.AMapper;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.Entities;
using Eg.Core.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System;

namespace ALaMarona.Core.Businesses
{
    public class ClienteBusiness : GenericBusiness<Cliente, long>, IClienteBusiness
    {
        public ClienteBusiness(IRepository<Cliente, long> repo) : base(repo)
        {
        }

        public Cliente Save(CreateClienteRequest createRequest)
        {
            if (Validate(createRequest))
            {
                Cliente cliente = new Cliente();
                MapRequest(createRequest, cliente);
                return base.Save(cliente);
            }
            else
            {
                //TODO: HABRIA QUE DEVOLVER UNA RESPUESTA QUE CONTENGA EL MENSAJE DE ERROR
                throw new ALaMaronaException("Cliente invalido");
            }
        }

        private void MapRequest(CreateClienteRequest createRequest, Cliente cliente)
        {
            cliente.Codigo = createRequest.Codigo;
            cliente.Documento = new Documento()
            {
                Numero = createRequest.NumeroDocumento,
                Tipo = createRequest.TipoDocumento
            };
            cliente.Domicilio = createRequest.Domicilio.MapDireccion();
            cliente.EMail = createRequest.EMail;
            cliente.EstadoCivil = createRequest.EstadoCivil;
            cliente.FechaNacimiento = DateTimeHelper.ParseDateNullable(createRequest.FechaNacimiento);
            cliente.LugarNacimiento = createRequest.LugarNacimiento.MapDireccion();
            cliente.Nombre = createRequest.MapNombre();
            cliente.Telefono = createRequest.Telefono;
        }

        public void Update(UpdateClienteRequest updateRequest)
        {
            if (!repository.Contains(x => x.Id == updateRequest.Id))
            {
                throw new System.Exception($"No se encontro el cliente Id {updateRequest.Id}");
            }

            if (Validate(updateRequest))
            {
                Cliente cliente = repository.First(x => x.Id == updateRequest.Id);
                MapRequest(updateRequest, cliente);
                base.Update(cliente);
            }
            else
            {
                //TODO: HABRIA QUE DEVOLVER UNA RESPUESTA QUE CONTENGA EL MENSAJE DE ERROR
                throw new ALaMaronaException("Cliente invalido");
            }
        }

        private bool Validate(CreateClienteRequest createClienteRequest)
        {
            if (createClienteRequest == null)
                return false;

            if (string.IsNullOrWhiteSpace(createClienteRequest.Codigo))
            {
                return false;
            }
            else if (repository.Contains(x => x.Id != createClienteRequest.Id && x.Codigo.Equals(createClienteRequest.Codigo)))
            {
                return false;
            }

            if (repository.Contains(x => x.Id != createClienteRequest.Id && x.Documento.Tipo.Equals(createClienteRequest.TipoDocumento)
                && x.Documento.Numero.Equals(createClienteRequest.NumeroDocumento)))
            {
                return false;
            }

            if (!ValidateEMailAddress(createClienteRequest))
            {
                return false;
            }

            return true;
        }

        private bool ValidateEMailAddress(CreateClienteRequest createClienteRequest)
        {
            if (!string.IsNullOrWhiteSpace(createClienteRequest.EMail))
            {
                var regex = new Regex(@"^(?("")("".+?(?<!\\)""@) | (([0 - 9a - z]((\.(? !\.)) |[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                try
                {
                    if (!regex.IsMatch(createClienteRequest.EMail))
                    {
                        return false;
                    }
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }

                if (repository.Contains(x => x.EMail.Equals(createClienteRequest.EMail, System.StringComparison.InvariantCultureIgnoreCase)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
