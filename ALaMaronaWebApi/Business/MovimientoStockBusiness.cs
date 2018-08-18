using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Entities;
using ALaMarona.Domain.Repositories;
using Eg.Core.Data;

namespace ALaMarona.Core.Business
{
    public class MovimientoStockBusiness : GenericBusiness<MovimientoStock, long>, IMovimientoStockBusiness
    {
        private readonly IMovimientoStockRepository _movimientoStockRepo;

        public MovimientoStockBusiness(IMovimientoStockRepository movimientoStockRepo) : base((IRepository<MovimientoStock, long>)movimientoStockRepo)
        {
            _movimientoStockRepo = movimientoStockRepo;
        }
    }
}
