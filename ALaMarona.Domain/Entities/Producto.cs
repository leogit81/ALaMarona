using Eg.Core;
using System.Collections.Generic;

namespace ALaMarona.Domain.Entities
{
    public class Producto : Entity<long>
    {
        public new virtual long Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
        public virtual string Codigo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int Talle { get; set; }
        public virtual Color Color { get; set; }
        public virtual ISet<Imagen> Imagenes { get; set; }
        public virtual ISet<MovimientoStock> MovimientosDeStock { get; set; }
    }
}