using ALaMarona.Core.Controller;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using ALaMarona.Domain.Generic;
using System.Web.Http;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Producto")]
    public class ProductoController : GenericController<Producto, long, ProductoDTO>
    {
        public ProductoController(IGenericBusiness<Producto, long> genericBusiness) : base(genericBusiness)
        {
        }
    }
}
