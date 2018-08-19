using ALaMarona.Core.Controller;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using System.Web.Http;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Producto")]
    public class ProductoController : GenericController<Producto, long, ProductoDTO>
    {
        public ProductoController(IProductoBusiness prodBusiness) : base(prodBusiness)
        {
        }
    }
}
