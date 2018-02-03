using ALaMarona.Core.Services;
using AutoMapper;
using Eg.Core;
using Eg.Core.Data.Impl;
using Eg.Core.DTOs;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ALaMarona.Core.Controller
{
    public class GenericController<T, TId, TDTO>: ApiController where T : Entity<TId>, new() where TDTO: GenericDTO<TId>, new()
    {
        private readonly IGenericService<T, TId> _genericService;

        public GenericController(IGenericService<T, TId> genericService)
        {
            //TODO: resolver por injección de dependencias
            ISessionFactory sessionFactory = (ISessionFactory)HttpContext.Current.Application["SessionFactory"];
            var repo = new NHibernateRepository<T, TId>(sessionFactory);
            _genericService = genericService;
        }

        [Route("")]
        // GET: api/Producto
        public virtual IEnumerable<TDTO> Get()
        {
            return _genericService.Get().Select(x => Mapper.Map<TDTO>(x));
        }

        [Route("id")]
        // GET: api/Producto/5
        public virtual TDTO Get(TId id)
        {
            return Mapper.Map<TDTO>(_genericService.Get(id));
        }

        [Route("")]
        [HttpPost]
        // POST: api/Producto
        public virtual void Post([FromBody]TDTO entityDto)
        {
            var entity = Mapper.Map<T>(entityDto);
            _genericService.Save(entity);
        }

        [Route("{id}")]
        // PUT: api/Producto/5
        public virtual void Put([FromBody]TDTO entityDto)
        {
            var entity = Mapper.Map<T>(entityDto);
            _genericService.Update(entity);
        }

        [Route("{id}")]
        // DELETE: api/Producto/5
        public virtual void Delete(TId id)
        {
            _genericService.Delete(id);
        }
    }
}
