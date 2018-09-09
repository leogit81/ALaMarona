using ALaMarona.Core.Generic.Controller;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using ALaMarona.Domain.Generic;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Http;

namespace ALaMarona.Core.Controller
{
    [RoutePrefix("api/Cliente")]
    public class ClienteController : BaseApiController<Cliente, long>
    {
        protected IClienteBusiness ClienteBusiness
        {
            get
            {
                return (IClienteBusiness)GenericBusiness;
            }
        }
        public ClienteController(IClienteBusiness clienteBusiness) : base((IGenericBusiness<Cliente, long>)clienteBusiness)
        {
        }

        [Route("")]
        public IEnumerable<ClienteDTO> Get()
        {
            var clientes = ClienteBusiness.GetAll();
            return Mapper.Map<IList<ClienteDTO>>(clientes);
        }

        [Route("id")]
        public ClienteDTO Get(long id)
        {
            return Mapper.Map<ClienteDTO>(ClienteBusiness.GetById(id));
        }

        [Route("")]
        [HttpPost]
        public ClienteDTO Post([FromBody]CreateClienteRequest createRequest)
        {
            var cliente = ClienteBusiness.Save(createRequest);
            return Mapper.Map<ClienteDTO>(cliente);
        }

        [Route("")]
        public void Put([FromBody]UpdateClienteRequest updateRequest)
        {
            ClienteBusiness.Update(updateRequest);
        }

        [Route("{id}")]
        public void Delete(long id)
        {
            ClienteBusiness.Delete(id);
        }
    }
}
