using ALaMarona.Core.Business;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Entities;
using Eg.Core.Data;

namespace ALaMarona.Core.Businesses
{
    public class DireccionBusiness : GenericBusiness<Direccion, long>, IDireccionBusiness
    {
        public DireccionBusiness(IRepository<Direccion, long> repo) : base(repo)
        {
        }
    }
}
