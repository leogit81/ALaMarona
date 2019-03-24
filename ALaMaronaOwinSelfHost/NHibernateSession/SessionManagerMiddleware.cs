using ALaMarona.Core.DI;
using Microsoft.Owin;
using NHibernate;
using NHibernate.Context;
using System;
using System.Threading.Tasks;

namespace ALaMaronaOwinSelfHost
{
    public class SessionManagerMiddleware : OwinMiddleware
    {
        public SessionManagerMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            OwinContextProvider.Context = context;
            BeginRequest();
            bool rollback = false;
            try
            {
                await Next.Invoke(context);
            }
            catch(Exception)
            {
                rollback = true;
            }

            if (context.Response.StatusCode >= 400)
            {
                rollback = true;
            }

            EndRequest(rollback);
        }

        protected void BeginRequest()
        {
            ISession session = (ISession)DIContainer.Kernel.GetService(typeof(ISession));
            CurrentSessionContext.Bind(session);
            session.BeginTransaction();
        }

        protected void EndRequest(bool rollback)
        {
            ISessionFactory sessionFactory = (ISessionFactory)DIContainer.Kernel.GetService(typeof(ISessionFactory));
            using (ISession session = CurrentSessionContext.Unbind(sessionFactory))
            {
                CurrentSessionContext.Unbind(session.SessionFactory);
                if (session.Transaction != null
                    && session.Transaction.IsActive
                    && rollback)
                {
                    session.Transaction.Rollback();
                }
                else
                {
                    session.Transaction.Commit();
                }
                session.Close();
            }
        }
    }

    public class FailMiddleware : OwinMiddleware
    {
        public FailMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            throw new NotImplementedException();
        }
    }
}