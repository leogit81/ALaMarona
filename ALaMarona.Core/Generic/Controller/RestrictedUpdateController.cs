using ALaMarona.Domain.Generic;
using AutoMapper;
using Eg.Core;
using Eg.Core.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ALaMarona.Core.Generic.Controller
{
    public abstract class RestrictedUpdateController<T, TId, TDTO, TUReq> : ApiController
        where T : Entity<TId>, new()
        where TDTO : GenericDTO<TId>, new()
        where TId : struct
        where TUReq: IUpdateRequest<TId>
    {
        private readonly RestrictedUpdateBusiness<T, TId, TUReq> _restrictedUpdateBusiness;

        public RestrictedUpdateController(RestrictedUpdateBusiness<T, TId, TUReq> restrictedUpdateBusiness)
        {
            _restrictedUpdateBusiness = restrictedUpdateBusiness;
        }

        [Route("")]
        // GET: api/Producto
        public virtual IEnumerable<TDTO> Get()
        {
            return _restrictedUpdateBusiness.GetAll().Select(x => Mapper.Map<TDTO>(x));
        }

        [Route("id")]
        // GET: api/Producto/5
        public virtual TDTO Get(TId id)
        {
            return Mapper.Map<TDTO>(_restrictedUpdateBusiness.GetById(id));
        }

        [Route("")]
        [HttpPost]
        // POST: api/Producto
        public virtual TDTO Post([FromBody]TDTO entityDto)
        {
            var entity = Mapper.Map<T>(entityDto);
            _restrictedUpdateBusiness.Save(entity);
            return Mapper.Map<TDTO>(entity);
        }

        [Route("")]
        // PUT: api/Producto
        public virtual void Put([FromBody]TUReq updateRequest)
        {
            _restrictedUpdateBusiness.Update(updateRequest);
        }

        [Route("{id}")]
        // DELETE: api/Producto/5
        public virtual void Delete(TId id)
        {
            _restrictedUpdateBusiness.Delete(id);
        }
    }
}
