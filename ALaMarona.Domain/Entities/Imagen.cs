using Eg.Core;

namespace ALaMarona.Domain.Entities
{
    public class Imagen: Entity<long>
    {
        public virtual string Nombre { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual byte[] Content { get; set; }
    }
}
