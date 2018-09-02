using Eg.Core;

namespace ALaMarona.Domain.Entities
{
    public class DetallePedido: Entity<long>
    {
        public virtual long IdProducto { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual decimal Precio { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual MovimientoStock MovimientoStock { get; set; }
    }
}
