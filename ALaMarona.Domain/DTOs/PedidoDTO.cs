using Eg.Core.DTOs;
using System.Collections.Generic;

namespace ALaMarona.Domain.DTOs
{
    public class PedidoDTO : GenericDTO<long>
    {
        public long Id { get; set; }
        public string Fecha { get; set; }
        public IList<DetallePedidoDTO> Detalles { get; set; }
    }
}