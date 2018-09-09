using ALaMarona.Core.Business;
using ALaMarona.Core.Businesses;
using ALaMarona.Domain.Businesses;
using ALaMarona.Domain.Generic;
using Ninject.Modules;

namespace ALaMarona.Core.DIExtension
{
    public static class DIExtensions
    {
        public static void BindBusinesses(this NinjectModule iocModule){
            iocModule.Bind(typeof(IGenericBusiness<,>)).To(typeof(GenericBusiness<,>));
            iocModule.Bind<IProductoBusiness>().To<ProductoBusiness>();
            iocModule.Bind<IPedidoBusiness>().To<PedidoBusiness>();
            iocModule.Bind<IClienteBusiness>().To<ClienteBusiness>();
        }
    }
}
