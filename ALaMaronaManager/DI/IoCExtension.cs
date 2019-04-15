using AutoMapper;
using Ninject.Modules;
using System;

namespace ALaMaronaManager.DI
{
    public static class IoCExtension
    {
        public static void BindMapper(this NinjectModule module, Action<IMapperConfigurationExpression> mapperConfiguration)
        {
            var mapperCfg = new MapperConfiguration(mapperConfiguration);

            module.Bind<IMapper>().ToMethod(x => mapperCfg.CreateMapper()).InThreadScope();
        }
    }
}
