namespace ALaMarona.Domain.Entities
{
    public class Cliente: Persona
    {
        public virtual string Codigo { get; set; }
        public virtual string EMail { get; set; }
    }
}
