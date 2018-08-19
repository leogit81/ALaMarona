using Eg.Core.DTOs;
using System;
using System.Collections.Generic;

namespace ALaMarona.Domain.DTOs
{
    public class MovimientoStockDTO : GenericDTO<long>
    {
        public MovimientoStockDTO() {
        }

        public string Fecha { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public long IdProducto { get; set; }
    }
}