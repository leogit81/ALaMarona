using ALaMarona.Core.Generic;
using ALaMarona.Core.Generic.Controller;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using System.Web.Http;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Producto")]
    public class ProductoController : RestrictedUpdateController<Producto, long, ProductoDTO, UpdateProductRequest>
    {
        private readonly IProductoBusiness _productoBusiness;

        public ProductoController(IProductoBusiness productoBusiness) : base((RestrictedUpdateBusiness<Producto, long, UpdateProductRequest>)productoBusiness)
        {
            _productoBusiness = productoBusiness;
        }
    }
}
