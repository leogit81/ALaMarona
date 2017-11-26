using Eg.Core.DTOs;

namespace ALaMarona.Domain.DTOs
{
    public class ColorDTO : GenericDTO<long>
    {
        public string CodigoHexa { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}