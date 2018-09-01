using ALaMarona.Core.Generic.Controller;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using ALaMarona.Domain.Generic;
using System.Web.Http;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/MovimientoStock")]
    public class MovimientoStockController : GenericController<MovimientoStock, long, MovimientoStockDTO>
    {
        public MovimientoStockController(IGenericBusiness<MovimientoStock, long> genericBusiness) : base(genericBusiness)
        {
        }
    }
}
