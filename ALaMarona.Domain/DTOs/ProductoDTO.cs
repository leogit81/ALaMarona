using Eg.Core.DTOs;
using System.Collections.Generic;

namespace ALaMarona.Domain.DTOs
{
    public class ProductoDTO : GenericDTO<long>
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Talle { get; set; }
        public ColorDTO Color { get; set; }
        public IList<ImagenDTO> Imagenes { get; set; }
        public IList<MovimientoStockDTO> MovimientosDeStock { get; set; }
    }
}