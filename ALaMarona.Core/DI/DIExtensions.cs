using ALaMarona.Core.Business;
using ALaMarona.Core.Businesses;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Generic;
using Ninject.Extensions.NamedScope;
using Ninject.Modules;

namespace ALaMarona.Core.DI
{
    public static class DIExtensions
    {
        public static void BindBusinesses(this NinjectModule iocModule){
            iocModule.Bind(typeof(IGenericBusiness<,>)).To(typeof(GenericBusiness<,>));
            iocModule.Bind<IProductoBusiness>().To<ProductoBusiness>();
            iocModule.Bind<IPedidoBusiness>().To<PedidoBusiness>();
            iocModule.Bind<IClienteBusiness>().To<ClienteBusiness>();
        }

        public static void BindBusinessesNamedScoped(this NinjectModule iocModule, string NamedScope)
        {
            iocModule.Bind(typeof(IGenericBusiness<,>)).To(typeof(GenericBusiness<,>)).InNamedScope(NamedScope);
            iocModule.Bind<IProductoBusiness>().To<ProductoBusiness>().InNamedScope(NamedScope);
            iocModule.Bind<IPedidoBusiness>().To<PedidoBusiness>().InNamedScope(NamedScope);
            iocModule.Bind<IClienteBusiness>().To<ClienteBusiness>().InNamedScope(NamedScope);
            iocModule.Bind<IPaisBusiness>().To<PaisBusiness>().InNamedScope(NamedScope);
        }
    }
}
