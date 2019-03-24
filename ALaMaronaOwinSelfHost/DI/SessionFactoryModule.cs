using NHibernate;
using NHibernate.Cfg;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace ALaMaronaOwinSelfHost.DI
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

            // Bind the ISession 
            this.Kernel.Bind<ISession>().ToMethod(
                (context) =>
                {
                    var factory = context.Kernel.Get<ISessionFactory>();
                    return factory.OpenSession();
                }
            ).InRequestScope();
        }
    }
}