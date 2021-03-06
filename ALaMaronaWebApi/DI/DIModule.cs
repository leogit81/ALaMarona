﻿using ALaMarona.Core.DI;
using ALaMaronaDAL.IoCExtension;
using Ninject.Modules;

namespace ALaMaronaWebApi.DI
{
    public class DIModule : NinjectModule
    {
        public DIModule()
        {
        }

        public override void Load()
        {
            this.BindBusinesses();
            this.BindDAL();
            this.Bind<NHibernate.ISessionFactory>().ToMethod(_ => WebApiApplication.SessionFactory).InSingletonScope();
        }
    }
}