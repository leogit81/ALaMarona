namespace ALaMarona.Domain.Contracts
{
    public class CreateClienteRequest: CreatePersonaRequest
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string EMail { get; set; }
    }
}
