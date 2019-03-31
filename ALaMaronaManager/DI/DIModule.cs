using ALaMarona.Core.Businesses;
using ALaMarona.Domain.Businesses;
using ALaMaronaDAL.IoCExtension;
using NHibernate;
using Ninject;
using Ninject.Extensions.ContextPreservation;
using Ninject.Extensions.Factory;
using Ninject.Extensions.NamedScope;
using Ninject.Modules;

namespace ALaMaronaManager.DI
{
    public class DIModule : NinjectModule
    {
        public DIModule()
        {
        }

        public override void Load()
        {
            this.Bind<IALaMaronaManagerFactory>().ToFactory().InSingletonScope();

            const string FormNamedScope = "Form";

            this.Bind<ClienteFormContext>().ToSelf().DefinesNamedScope(FormNamedScope);
            this.Bind<IClienteBusiness>().To<ClienteBusiness>().InNamedScope(FormNamedScope);
            // Bind the NHibernate-ISession 
            this.Kernel.Bind<ISession>().ToMethod(
                (context) =>
                {
                    var factory = context.Kernel.Get<ISessionFactory>();
                    return factory.OpenSession();
                }
            );

            this.BindDAL();
        }
    }
}