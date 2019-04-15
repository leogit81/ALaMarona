using ALaMarona.Domain.Businesses;
using AutoMapper;

namespace ALaMaronaManager
{
    public class PedidoFormContext
    {
        public IPedidoBusiness PedidoBus { get; protected set; }
        public IClienteBusiness ClienteBus { get; protected set; }
        public IMapper Mapper { get; protected set; }

        public PedidoFormContext(IPedidoBusiness pedidoBus,
            IClienteBusiness cliBus,
            IMapper mapper)
        {
            PedidoBus = pedidoBus;
            ClienteBus = cliBus;
            Mapper = mapper;
        }
    }
}
