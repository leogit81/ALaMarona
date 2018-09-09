namespace ALaMarona.Domain.Contracts
{
    public class CreatePersonaRequest
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido { get; set; }
        public string Alias { get; set; }
        public CreateDireccionRequest Domicilio { get; set; }
        public string Telefono { get; set; }
        public string TipoDocumento { get; set; }
        public long NumeroDocumento { get; set; }
        public string FechaNacimiento { get; set; }
        public CreateDireccionRequest LugarNacimiento { get; set; }
        public string EstadoCivil { get; set; }
    }
}
