using Eg.Core.DTOs;

namespace ALaMarona.Domain.DTOs
{
    public class ImagenDTO : GenericDTO<long>
    { 
        public string Nombre { get; set; }
        public ProductoDTO Producto { get; set; }
        public byte[] ImagenProducto { get; set; }
    }
}