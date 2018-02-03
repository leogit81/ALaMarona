using ALaMarona.Core.Controller;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using System.Web.Http;
using ALaMarona.Core.Services;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Stock")]
    public class StockController : GenericController<MovimientoStock, long, MovimientoStockDTO>
    {
        public StockController(MovimientoStockService service) : base(service)
        {
        }
    }
}
