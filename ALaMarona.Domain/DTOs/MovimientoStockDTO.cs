using Eg.Core.DTOs;
using System;
using System.Collections.Generic;

namespace ALaMarona.Domain.DTOs
{
    public class MovimientoStockDTO : GenericDTO<long>
    {
        public MovimientoStockDTO() {
        }

        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}