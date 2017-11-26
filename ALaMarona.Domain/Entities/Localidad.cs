using Eg.Core;

namespace ALaMarona.Domain.Entities
{
    public class Localidad : Entity<long>
    {
        public virtual string Nombre { get; set; }
        public virtual Provincia Provincia { get; set; }
    }
}