using ALaMarona.Domain.Entities;

namespace ALaMarona.Domain.Repositories
{
    public interface IMovimientoStockRepository
    {
        int Count { get; }
        void Add(MovimientoStock movimientoStock);
        bool Contains(MovimientoStock movimientoStock);
        bool Remove(MovimientoStock movimientoStock);
        void Update(MovimientoStock movimientoStock);
    }
}
