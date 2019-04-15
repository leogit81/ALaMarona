using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Entities;
using AutoMapper;

namespace ALaMaronaManager
{
    public class ClienteFormContext
    {
        public IClienteBusiness ClienteBus { get; protected set; }
        public IPaisBusiness PaisBus { get; protected set; }
        public IMapper Mapper { get; protected set; }
        public Cliente SelectedClient { get; set; }

        public ClienteFormContext(
            IALaMaronaManagerFactory factory,
            IClienteBusiness cliBus,
            IPaisBusiness paisBus,
            IMapper mapper)
        {
            ClienteBus = cliBus;
            PaisBus = paisBus;
            Mapper = mapper;
        }
    }
}
