using Eg.Core.DTOs;

namespace ALaMarona.Domain.DTOs
{
    public class LocalidadDTO : GenericDTO<long>
    { 
        public string Nombre { get; set; }
        public ProvinciaDTO Provincia { get; set; }
    }
}