using ALaMarona.Core.Generic;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.Entities;
using Eg.Core.Data;
using System.Linq;

namespace ALaMarona.Core.Business
{
    public class PedidoBusiness : RestrictedUpdateBusiness<Pedido, long, UpdatePedidoRequest>, IPedidoBusiness
    {
        private readonly IProductoBusiness _productoBusiness;

        public PedidoBusiness(IRepository<Pedido, long> repo, IProductoBusiness prodBus) : base(repo)
        {
            _productoBusiness = prodBus;
        }

        public override Pedido Save(Pedido entity)
        {
            var results =
                from d in entity.Detalles
                join p in _productoBusiness.GetAll() on d.IdProducto equals p.Id into pg
                from g in pg.DefaultIfEmpty()
                select new { DetallePedido = d, Producto = g };

            if (results.Any(x => x.Producto == null))
            {
                var idProducto = results.FirstOrDefault(x => x.Producto == null).DetallePedido.IdProducto;
                throw new ALaMaronaException($"El Id de Producto {idProducto} no existe.");
            }

            foreach (var r in results)
            {
                r.DetallePedido.Pedido = entity;
                r.DetallePedido.Producto = r.Producto;
                r.DetallePedido.MovimientoStock = new MovimientoStock(r.DetallePedido);
            }
            repository.Add(entity);
            return entity;
        }

        protected override Pedido MapUpdateRequestToEntity(UpdatePedidoRequest updateRequest)
        {
            var pedido = repository.FirstOrDefault(x => x.Id == updateRequest.Id);

            var joinedResults = from rd in updateRequest.Detalles
                                join d in pedido.Detalles on rd.Id equals d.Id into detailGroup
                                from dg in detailGroup.DefaultIfEmpty(new DetallePedido() { Pedido = pedido })
                                select new {
                                    DetallePedidoReq = rd,
                                    DetallePedido = dg,
                                    Producto = (from p in _productoBusiness.GetAll()
                                               where p.Id == rd.IdProducto
                                               select p).FirstOrDefault()
                                };

            if (joinedResults.Any(x => x.Producto == null))
            {
                var idProducto = joinedResults.FirstOrDefault(x => x.Producto == null).DetallePedidoReq.IdProducto;
                throw new ALaMaronaException($"El Id de Producto {idProducto} no existe.");
            }

            var deleted = pedido.Detalles.Where(x => !updateRequest.Detalles.Select(y => y.Id).Contains(x.Id)).ToList();

            foreach (var jr in joinedResults)
            {
                jr.DetallePedido.Cantidad = jr.DetallePedidoReq.Cantidad;
                jr.DetallePedido.Precio = jr.DetallePedidoReq.Precio;
                jr.DetallePedido.Producto = jr.Producto;

                if (jr.DetallePedido.Id == 0)
                {
                    pedido.Detalles.Add(jr.DetallePedido);
                    jr.DetallePedido.MovimientoStock = new MovimientoStock(jr.DetallePedido);
                }
                else
                {
                    jr.DetallePedido.MovimientoStock?.Update(jr.DetallePedido);
                }
            }

            foreach (var del in deleted)
            {
                pedido.Detalles.Remove(del);
            }

            return pedido;
        }
    }
}
