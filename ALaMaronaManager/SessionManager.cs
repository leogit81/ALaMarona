using ALaMarona.Core.DI;
using NHibernate;
using NHibernate.Context;

namespace ALaMaronaManager
{
    public static class SessionManager
    {
        public static void BindSession()
        {
            ISession session = (ISession)DIContainer.Kernel.GetService(typeof(ISession));
            CurrentSessionContext.Bind(session);
            session.BeginTransaction();
        }

        public static void UnbindSession(bool rollback = false)
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
}
