using ALaMarona.Domain.Businesses;

namespace ALaMaronaManager
{
    public class ClienteFormContext
    {
        public IClienteBusiness ClienteBus { get; protected set; }

        public ClienteFormContext(IClienteBusiness cliBus)
        {
            ClienteBus = cliBus;
        }
    }
}
