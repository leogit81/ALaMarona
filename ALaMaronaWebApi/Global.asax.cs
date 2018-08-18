using ALaMarona.Core;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using Ninject;
using Ninject.Web.Common.WebHost;
using Ninject.Web.WebApi;
using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace ALaMaronaWebApi
{
    public class WebApiApplication : NinjectHttpApplication
    {
        public static ISessionFactory SessionFactory = CreateSessionFactory();

        public WebApiApplication()
        {
            this.BeginRequest += new EventHandler(Application_BeginRequest);
            this.EndRequest += new EventHandler(Application_EndRequest);
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var cfg = new Configuration().Configure();
            return cfg.BuildSessionFactory();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            Factory.Instance.ConfigureMapping();
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            return kernel;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            WebSessionContext.Bind(SessionFactory.OpenSession());
        }

        protected void Application_EndRequest(
            object sender, EventArgs e)
        {
            ISession session = WebSessionContext.Unbind(SessionFactory);
            if (session != null)
            {
                if (session.Transaction != null &&
                    session.Transaction.IsActive)
                {
                    session.Transaction.Rollback();
                }
                else
                    session.Flush();
                session.Close();
            }
        }
    }
}
