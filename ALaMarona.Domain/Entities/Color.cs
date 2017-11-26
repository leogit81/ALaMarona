using Eg.Core;
using System.Collections.Generic;

namespace ALaMarona.Domain.Entities
{
    public class Color : Entity<long>
    {
        public Color() {
            Productos = new HashSet<Producto>();
        }

        public virtual string CodigoHexa { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual ISet<Producto> Productos { get; set; }
    }
}
