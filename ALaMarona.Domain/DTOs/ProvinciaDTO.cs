using Eg.Core.DTOs;
using System.Collections.Generic;

namespace ALaMarona.Domain.DTOs
{
    public class ProvinciaDTO : GenericDTO<long>
    {
        public ProvinciaDTO() {
            IdLocalidades = new List<int>();
        }

        public string Nombre { get; set; }

        public IList<int> IdLocalidades { get; set; }
        public int IdPais { get; set; }
    }
}