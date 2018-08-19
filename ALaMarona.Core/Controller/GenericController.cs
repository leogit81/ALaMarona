using ALaMarona.Domain.Generic;
using AutoMapper;
using Eg.Core;
using Eg.Core.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ALaMarona.Core.Controller
{
    public class GenericController<T, TId, TDTO>: ApiController where T : Entity<TId>, new() where TDTO: GenericDTO<TId>, new()
    {
        private readonly IGenericBusiness<T, TId> _genericBusiness;

        public GenericController(IGenericBusiness<T, TId> genericBusiness)
        {
            //ISessionFactory sessionFactory = (ISessionFactory)HttpContext.Current.Application["SessionFactory"];
            //var repo = new NHibernateRepository<T, TId>(sessionFactory);
            _genericBusiness = genericBusiness;
        }

        [Route("")]
        // GET: api/Producto
        public virtual IEnumerable<TDTO> Get()
        {
            return _genericBusiness.GetAll().Select(x => Mapper.Map<TDTO>(x));
        }

        [Route("id")]
        // GET: api/Producto/5
        public virtual TDTO Get(TId id)
        {
            return Mapper.Map<TDTO>(_genericBusiness.GetById(id));
        }

        [Route("")]
        [HttpPost]
        // POST: api/Producto
        public virtual TDTO Post([FromBody]TDTO entityDto)
        {
            var entity = Mapper.Map<T>(entityDto);
            _genericBusiness.Save(entity);
            return Mapper.Map<TDTO>(entity);
        }

        [Route("{id}")]
        // PUT: api/Producto/5
        public virtual void Put([FromBody]TDTO entityDto)
        {
            var entity = Mapper.Map<T>(entityDto);
            _genericBusiness.Update(entity);
        }

        [Route("{id}")]
        // DELETE: api/Producto/5
        public virtual void Delete(TId id)
        {
            _genericBusiness.Delete(id);
        }
    }
}
