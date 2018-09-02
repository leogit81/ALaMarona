using Eg.Core;
using System;

namespace ALaMarona.Domain.Entities
{
    public class MovimientoStock : Entity<long>
    {
        public MovimientoStock()
        {
        }

        public MovimientoStock(DetallePedido detallePedido)
        {
            Cantidad = -detallePedido.Cantidad;
            Fecha = detallePedido.Pedido.Fecha;
            Precio = detallePedido.Precio;
            Producto = detallePedido.Producto;
        }

        public virtual Producto Producto { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual decimal Precio { get; set; }

        public virtual void Update(DetallePedido detallePedido)
        {
            this.Cantidad = -detallePedido.Cantidad;
            this.Precio = detallePedido.Precio;
            this.Producto = detallePedido.Producto;
        }
    }
}