using Eg.Core.DTOs;

namespace ALaMarona.Domain.DTOs
{
    public class DetallePedidoDTO : GenericDTO<long>
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public long IdProducto { get; set; }
    }
}