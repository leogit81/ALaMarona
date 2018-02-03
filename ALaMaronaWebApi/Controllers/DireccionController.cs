using System.Web.Http;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using ALaMarona.Core.Controller;
using ALaMarona.Core.Services;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Direccion")]
    public class DireccionController : GenericController<Direccion, long, DireccionDTO>
    {
        public DireccionController(IGenericService<Direccion, long> genericService) : base(genericService)
        {
        }
    }
}
