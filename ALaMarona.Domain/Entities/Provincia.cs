using Eg.Core;
using System.Collections.Generic;

namespace ALaMarona.Domain.Entities
{
    public class Provincia: Entity<long>
    {
        public Provincia() {
            Localidades = new HashSet<Localidad>();
        }

        public virtual string Nombre { get; set; }

        public virtual ISet<Localidad> Localidades { get; set; }
        public virtual Pais Pais { get; set; }
    }
}