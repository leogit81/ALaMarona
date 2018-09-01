using ALaMarona.Core.Generic;
using ALaMarona.Core.Generic.Controller;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using System.Web.Http;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Pedido")]
    public class PedidoController : RestrictedUpdateController<Pedido, long, PedidoDTO, UpdatePedidoRequest>
    {
        private readonly IPedidoBusiness _pedidoBusiness;

        public PedidoController(IPedidoBusiness pedidoBusiness) : base((RestrictedUpdateBusiness<Pedido, long, UpdatePedidoRequest>)pedidoBusiness)
        {
            _pedidoBusiness = pedidoBusiness;
        }
    }
}
