using ALaMarona.Core;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using System;
using System.Web;
using System.Web.Http;

namespace ALaMaronaWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private ISessionFactory getSessionFactory()
        {
            return (ISessionFactory)HttpContext.Current.Application["SessionFactory"];
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var nhConfig = new Configuration().Configure();
            HttpContext.Current.Application["SessionFactory"] = nhConfig.BuildSessionFactory();

            Factory.Instance.ConfigureMapping();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            WebSessionContext.Bind(getSessionFactory().OpenSession());
        }

        protected void Application_EndRequest(
            object sender, EventArgs e)
        {
            ISession session = WebSessionContext.Unbind(getSessionFactory());
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
