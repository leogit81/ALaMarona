using Eg.Core.Data;
using Eg.Core.Data.Impl;
using Ninject.Modules;

namespace ALaMaronaDAL.IoCExtension
{
    public static class IoCExtensions
    {
        public static void BindDAL(this NinjectModule iocModule){
            iocModule.Bind(typeof(IRepository<,>)).To(typeof(NHibernateRepository<,>));
        }
    }
}