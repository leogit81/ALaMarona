using ALaMarona.Core.Business;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Generic;
using Ninject.Modules;

namespace ALaMarona.Core.IoCExtension
{
    public static class IoCExtensions
    {
        public static void BindBusinesses(this NinjectModule iocModule){
            iocModule.Bind(typeof(IGenericBusiness<,>)).To(typeof(GenericBusiness<,>));
            iocModule.Bind<IProductoBusiness>().To<ProductoBusiness>();
        }

        //public static void BindSessionManager(this NinjectModule iocModule)
        //{
        //    iocModule.Bind<NHibernate.ISessionFactory>().ToMethod(_ => NHibernateSessionManager.SessionFactory).InSingletonScope();
        //    iocModule.Bind<NHibernate.ISession>().ToMethod(_ => NHibernateSessionManager.CurrentSession).InTransientScope();
        //    iocModule.Bind<NHibernate.IStatelessSession>().ToMethod(_ => NHibernateSessionManager.CurrentStatelessSession).InTransientScope();
        //}
    }
}