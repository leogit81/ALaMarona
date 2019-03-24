using ALaMarona.Core.AMapper;
using ALaMarona.Core.DI;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Reflection;
using System.Web.Http;

namespace ALaMaronaOwinSelfHost
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            MappersConfigurator.ConfigureMapping();

            // Configure Web API for self-host. 
            var configuration = new HttpConfiguration();

            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder
                .Use<SessionManagerMiddleware>()
                .UseNinjectMiddleware(CreateKernel)
                .UseNinjectWebApi(configuration);
        }

        protected IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            DIContainer.Kernel = kernel;
            return kernel;
        }
    }
}