using ALaMarona.Core.AMapper;
using ALaMarona.Core.Business;
using ALaMarona.Core.Helpers;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.Entities;
using Eg.Core.Data;
using System;
using System.Linq;
using System.Net.Mail;

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
            try
            {
                MailAddress mailAddress = new MailAddress(createClienteRequest.EMail);
            }
            catch (Exception)
            {
                return false;
            }

            if (repository.Contains(x => x.Id != createClienteRequest.Id
                && createClienteRequest.EMail.Equals(x.EMail, System.StringComparison.InvariantCultureIgnoreCase)))
            {
                return false;
            }

            return true;
        }

        public static string GetNombreCliente(ALaMarona.Domain.Entities.Cliente x)
        {
            string nombreCliente = string.Empty;

            if (x.Nombre != null
            && !string.IsNullOrEmpty(x.Nombre.Apellido)
            && !string.IsNullOrEmpty(x.Nombre.Primero))
            {
                nombreCliente = x.Nombre?.Apellido + ", " + x.Nombre?.Primero;
            }
            else if (x.Nombre != null && !string.IsNullOrEmpty(x.Nombre.Alias))
            {
                nombreCliente = x.Nombre.Alias;
            }
            else if (!string.IsNullOrEmpty(x.EMail))
            {
                nombreCliente = x.EMail;
            }
            return nombreCliente;
        }
    }
}