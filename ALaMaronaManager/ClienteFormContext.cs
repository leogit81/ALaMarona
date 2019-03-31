using ALaMarona.Domain.Businesses;
using ALaMaronaManager.DI;

namespace ALaMaronaManager
{
    public class ClienteFormContext: IFormContext
    {
        public IClienteBusiness ClienteBus { get; protected set; }

        public ClienteFormContext(IClienteBusiness cliBus)
        {
            ClienteBus = cliBus;
        }
    }
}
