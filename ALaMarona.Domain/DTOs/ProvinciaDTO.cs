using Eg.Core.DTOs;
using System.Collections.Generic;

namespace ALaMarona.Domain.DTOs
{
    public class ProvinciaDTO : GenericDTO<long>
    {
        public ProvinciaDTO() {
            Localidades = new HashSet<LocalidadDTO>();
        }

        public string Nombre { get; set; }

        public ISet<LocalidadDTO> Localidades { get; set; }
        public PaisDTO Pais { get; set; }
    }
}