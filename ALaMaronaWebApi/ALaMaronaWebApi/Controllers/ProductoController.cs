using System.Web.Http;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using ALaMarona.Core.Controller;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Producto")]
    public class ProductoController : GenericController<Producto, long, ProductoDTO, long>
    {
    }
}
