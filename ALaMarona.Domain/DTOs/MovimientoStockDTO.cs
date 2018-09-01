using Eg.Core.DTOs;

namespace ALaMarona.Domain.DTOs
{
    public class MovimientoStockDTO : GenericDTO<long>
    {
        public string Fecha { get; set; }
        /// <summary>
        /// Cantidad positiva para compras. Cantidad negativa para ventas.
        /// </summary>
        public int Cantidad { get; set; }
        /// <summary>
        /// Puede ser precio de compra cuando la cantidad es positiva. Precio de venta cuando la cantidad es negativa.
        /// </summary>
        public decimal Precio { get; set; }
        public long IdProducto { get; set; }
    }
}