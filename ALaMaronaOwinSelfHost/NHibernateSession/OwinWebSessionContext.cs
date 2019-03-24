using NHibernate.Context;
using NHibernate.Engine;
using System;
using System.Collections;

namespace ALaMaronaOwinSelfHost
{
    [Serializable]
    public class OwinWebSessionContext : MapBasedSessionContext
    {
        private const string SessionFactoryMapKey = "NHibernate.Context.OwinWebSessionContext.SessionFactoryMapKey";

        public OwinWebSessionContext(ISessionFactoryImplementor factory) : base(factory) { }

        protected override IDictionary GetMap()
        {
            return OwinContextProvider.Context.Get<IDictionary>(SessionFactoryMapKey);
        }

        protected override void SetMap(IDictionary value)
        {
            OwinContextProvider.Context.Set<IDictionary>(SessionFactoryMapKey, value);
        }
    }
}
