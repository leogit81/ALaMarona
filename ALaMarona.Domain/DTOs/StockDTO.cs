using Eg.Core.DTOs;
using System.Collections.Generic;

namespace ALaMarona.Domain.DTOs
{
    public class StockDTO : GenericDTO<long>
    {
        public StockDTO() {
            Movimientos = new List<MovimientoStockDTO>();
        }

        public ProductoDTO Producto { get; set; }
        public IList<MovimientoStockDTO> Movimientos { get; set; }
    }
}