using Eg.Core;
using System;
using System.Collections.Generic;

namespace ALaMarona.Domain.Entities
{
    public class Pedido: Entity<long>
    {
        public virtual DateTime Fecha { get; set; }
        public virtual ISet<DetallePedido> Detalles { get; set; }
    }
}
