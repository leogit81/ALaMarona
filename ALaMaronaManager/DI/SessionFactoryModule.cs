using NHibernate;
using NHibernate.Cfg;
using Ninject.Modules;

namespace ALaMaronaManager.DI
{
    public class SessionFactoryModule : NinjectModule
    {
        public override void Load()
        {
            // Bind the ISession Factory - Singleton as only ever need one of these
            this.Kernel.Bind<ISessionFactory>().ToMethod(x =>
            {
                var cfg = new Configuration().Configure();
                return cfg.BuildSessionFactory();
            }).InSingletonScope();
        }
    }
}