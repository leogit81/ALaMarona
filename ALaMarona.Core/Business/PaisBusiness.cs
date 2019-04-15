using ALaMarona.Core.Business;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Entities;
using Eg.Core.Data;
using System.Linq;

namespace ALaMarona.Core.Businesses
{
    public class PaisBusiness : GenericBusiness<Pais, long>, IPaisBusiness
    {
        protected IRepository<Provincia, long> _provinciaRepo;

        public PaisBusiness(IRepository<Pais, long> repo,
            IRepository<Provincia, long> provinciaRepo) : base(repo)
        {
            _provinciaRepo = provinciaRepo;
        }

        public void SaveLocalidad(Localidad localidad, long idProvincia)
        {
            var provincia = _provinciaRepo.FirstOrDefault(x => x.Id == idProvincia);

            if (provincia == null)
            {
                throw new ALaMaronaException($"No se pudo guardar la localidad porque no se encontró la provincia con id: {idProvincia}");
            }

            localidad.Provincia = provincia;
            Update(localidad.Provincia.Pais);
        }
    }
}