using ALaMarona.Domain.Generic;
using System.Collections.Generic;

namespace ALaMarona.Domain.Contracts
{
    public class UpdatePedidoRequest : IUpdateRequest<long>
    {
        public long Id { get; set; }
        public IList<UpdateDetallePedidoRequest> Detalles { get; set; }
    }
}
