using ALaMarona.Domain.Entities;
using System.Collections.Generic;

namespace ALaMarona.Domain.Businesses
{
    public interface IMovimientoStockBusiness
    {
        MovimientoStock GetById(long movimientoStockId);
        IList<MovimientoStock> GetAll();
        MovimientoStock Save(MovimientoStock movimientoStock);
        void Update(MovimientoStock movimientoStock);
        void Delete(long movimientoStockId);
    }
}
