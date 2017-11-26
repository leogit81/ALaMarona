using Eg.Core.DTOs;

namespace ALaMarona.Domain.DTOs
{
    public class DireccionDTO : GenericDTO<long>
    {
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public string CodigoPostal { get; set; }
        public PaisDTO Pais { get; set; }
        public ProvinciaDTO Provincia {get;set;}
        public LocalidadDTO Localidad { get; set; }
    }
}
