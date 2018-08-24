using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Producto")]
    public class ProductoController : ApiController
    {
        private readonly IProductoBusiness productoBusiness;

        public ProductoController(IProductoBusiness prodBusiness)
        {
            productoBusiness = prodBusiness;
        }

        [Route("")]
        // GET: api/Producto
        public virtual IEnumerable<ProductoDTO> Get()
        {
            return productoBusiness.GetAll().Select(x => Mapper.Map<ProductoDTO>(x));
        }

        [Route("{id}")]
        [HttpGet]
        // GET: api/Producto/5
        public virtual ProductoDTO Get(long id)
        {
            return Mapper.Map<ProductoDTO>(productoBusiness.GetById(id));
        }

        [Route("")]
        [HttpPost]
        // POST: api/Producto
        public virtual ProductoDTO Post([FromBody]ProductoDTO entityDto)
        {
            var entity = Mapper.Map<Producto>(entityDto);
            productoBusiness.Save(entity);
            return Mapper.Map<ProductoDTO>(entity);
        }

        [Route("")]
        // PUT: api/Producto
        public virtual void Put(UpdateProductRequest updateRequest)
        {
            productoBusiness.Update(updateRequest);
        }

        [Route("{id}")]
        // DELETE: api/Producto/5
        public virtual void Delete(long id)
        {
            productoBusiness.Delete(id);
        }
    }
}
