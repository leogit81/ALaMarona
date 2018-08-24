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
    }
}