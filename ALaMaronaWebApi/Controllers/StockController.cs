using ALaMarona.Core.Controller;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using ALaMarona.Domain.Generic;
using System.Web.Http;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Stock")]
    public class StockController : GenericController<MovimientoStock, long, MovimientoStockDTO>
    {
        private readonly IMovimientoStockBusiness _movimientoStockBus;

        public StockController(IMovimientoStockBusiness movimientoStockBus) : base((IGenericBusiness<MovimientoStock, long>)movimientoStockBus)
        {
            _movimientoStockBus = movimientoStockBus;
        }
    }
}
