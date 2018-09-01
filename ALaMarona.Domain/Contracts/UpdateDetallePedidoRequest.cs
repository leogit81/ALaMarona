using ALaMarona.Domain.Generic;

namespace ALaMarona.Domain.Contracts
{
    public class UpdateDetallePedidoRequest : IUpdateRequest<long>
    {
        public long Id { get; set; }
        public long IdProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
