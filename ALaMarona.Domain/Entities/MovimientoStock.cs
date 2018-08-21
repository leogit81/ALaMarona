using Eg.Core;
using System;

namespace ALaMarona.Domain.Entities
{
    public class MovimientoStock : Entity<long>
    {
        public MovimientoStock()
        {
        }

        public virtual Producto Producto { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual decimal Precio { get; set; }
    }
}