using Eg.Core;
using System.Collections.Generic;

namespace ALaMarona.Domain.Entities
{
    public class Pais : Entity<long>
    {
        public Pais() {
            Provincias = new HashSet<Provincia>();
        }

        public virtual string Nombre { get; set; }
        public virtual ISet<Provincia> Provincias { get; set; }
    }
}