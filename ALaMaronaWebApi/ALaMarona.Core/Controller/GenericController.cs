using ALaMarona.Core.Services;
using ALaMarona.Domain.DTOs;
using Eg.Core;
using System.Collections.Generic;
using System.Web.Http;
using Eg.Core.DTOs;
using Eg.Core.Data.Impl;
using System.Web;
using NHibernate;

namespace ALaMarona.Core.Controller
{
    public class GenericController<T, TId, TDTO, TDTOId>: ApiController where T : Entity<TId>, new() where TDTO: GenericDTO<TDTOId>, new()
    {
        IGenericService<TDTO, TDTOId> genericService;

        public GenericController()
        {
            //TODO: resolver por injección de dependencias
            var repo = new NHibernateRepository<T, TId>((ISessionFactory)HttpContext.Current.Application["SessionFactory"]);
            genericService = new GenericService<T, TId, TDTO, TDTOId>(repo);
        }

        [Route("")]
        // GET: api/Producto
        public virtual IEnumerable<TDTO> Get()
        {
            return genericService.Get();
        }

        [Route("id")]
        // GET: api/Producto/5
        public virtual TDTO Get(TDTOId id)
        {
            return genericService.Get(id);
        }

        [Route("")]
        [HttpPost]
        // POST: api/Producto
        public virtual void Post([FromBody]TDTO entityDto)
        {
            genericService.Save(entityDto);
        }

        [Route("{id}")]
        // PUT: api/Producto/5
        public virtual void Put([FromBody]TDTO entityDto)
        {
            genericService.Update(entityDto);
        }

        [Route("{id}")]
        // DELETE: api/Producto/5
        public virtual void Delete(TDTOId id)
        {
            genericService.Delete(id);
        }
    }
}
