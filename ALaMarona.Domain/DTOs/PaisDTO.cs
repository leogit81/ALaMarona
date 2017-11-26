using Eg.Core.DTOs;
using System.Collections.Generic;

namespace ALaMarona.Domain.DTOs
{
    public class PaisDTO : GenericDTO<long>
    {
        public PaisDTO() {
            Provincias = new HashSet<ProvinciaDTO>();
        }

        public string Nombre { get; set; }
        public ISet<ProvinciaDTO> Provincias { get; set; }
    }
}