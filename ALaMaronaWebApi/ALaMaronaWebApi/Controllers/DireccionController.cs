using System.Web.Http;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using ALaMarona.Core.Controller;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Direccion")]
    public class DireccionController : GenericController<Direccion, long, DireccionDTO, long>
    {
    }
}
