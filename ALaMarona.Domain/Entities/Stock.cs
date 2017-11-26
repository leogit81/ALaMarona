using Eg.Core;
using System.Collections.Generic;
using System.Linq;

namespace ALaMarona.Domain.Entities
{
    public class Stock : Entity<long>
    {
        public Stock()
        {
            _movimientos = new HashSet<MovimientoStock>();
        }

        public virtual Producto Producto { get; set; }
        protected ISet<MovimientoStock> _movimientos;

        public virtual void AgregarMovimiento(MovimientoStock mov)
        {
            _movimientos.Add(mov);
            mov.Stock = this;
        }

        public virtual void RemoverMovimiento(MovimientoStock mov)
        {
            _movimientos.Remove(mov);
            mov.Stock = null;
        }
    }
}