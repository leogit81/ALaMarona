namespace ALaMarona.Domain.Contracts
{
    public class CreateDireccionRequest
    {
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public string CodigoPostal { get; set; }
        public long IdPais { get; set; }
        public long IdProvincia { get; set; }
        public long IdLocalidad { get; set; }
    }
}
