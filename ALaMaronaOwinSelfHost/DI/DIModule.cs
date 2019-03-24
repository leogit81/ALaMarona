using ALaMarona.Core.DI;
using ALaMaronaDAL.IoCExtension;
using Ninject.Modules;

namespace ALaMaronaOwinSelfHost.DI
{
    public class DIModule : NinjectModule
    {
        public DIModule()
        {
        }

        public override void Load()
        {
            this.BindBusinesses();
            this.BindDAL();
        }
    }
}