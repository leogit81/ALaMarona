using ALaMarona.Core.Generic.Controller;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using ALaMarona.Domain.Generic;
using System.Web.Http;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Direccion")]
    public class DireccionController : GenericController<Direccion, long, DireccionDTO>
    {
        public DireccionController(IGenericBusiness<Direccion, long> genericBusiness) : base(genericBusiness)
        {
        }
    }
}
