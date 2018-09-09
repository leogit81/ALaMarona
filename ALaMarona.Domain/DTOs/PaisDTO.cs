using Eg.Core.DTOs;
using System.Collections.Generic;

namespace ALaMarona.Domain.DTOs
{
    public class PaisDTO : GenericDTO<long>
    {
        public PaisDTO() {
            IdProvincias = new List<int>();
        }

        public string Nombre { get; set; }
        public IList<int> IdProvincias { get; set; }
    }
}