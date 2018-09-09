namespace ALaMarona.Domain.Contracts
{
    public class CreateClienteRequest: CreatePersonaRequest
    {
        public string Codigo { get; set; }
        public string EMail { get; set; }
    }
}
