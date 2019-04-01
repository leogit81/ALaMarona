using ALaMarona.Domain.Businesses;

namespace ALaMaronaManager
{
    public class PedidoFormContext
    {
        public IPedidoBusiness PedidoBus { get; protected set; }
        public IClienteBusiness ClienteBus { get; protected set; }

        public PedidoFormContext(IPedidoBusiness pedidoBus,
            IClienteBusiness cliBus)
        {
            PedidoBus = pedidoBus;
            ClienteBus = cliBus;
        }
    }
}
