using ALaMarona.Domain.Generic;
using Eg.Core;
using System.Web.Http;

namespace ALaMarona.Core.Generic.Controller
{
    public class BaseApiController<T, TId>: ApiController where T : Entity<TId>, new()
    {
        protected readonly IGenericBusiness<T, TId> GenericBusiness;

        public BaseApiController(IGenericBusiness<T, TId> genericBusiness)
        {
            GenericBusiness = genericBusiness;
        }
    }
}
