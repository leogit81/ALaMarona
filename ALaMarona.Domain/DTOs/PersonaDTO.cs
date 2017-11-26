using Eg.Core.DTOs;
using System;

namespace ALaMarona.Domain.DTOs
{
    public class PersonaDTO : GenericDTO<long>
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido { get; set; }
        public string Alias { get; set; }
        public DireccionDTO Domicilio { get; set; }
        public string Telefono { get; set; }
        public string TipoDocumento { get; set; }
        public long NumeroDocumento { get; set; }
        public string FechaNacimiento { get; set; }
        public DireccionDTO LugarNacimiento { get; set; }
        public string EstadoCivil { get; set; }
    }
}