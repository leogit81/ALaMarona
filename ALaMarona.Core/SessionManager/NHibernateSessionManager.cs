using log4net;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Context;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using WebConfiguration = System.Configuration;

namespace ALaMarona.Core.SessionManager
{
    public class NHibernateSessionManager
    {
        private const string CONNECTION_STRING_NAME = "db";

        private static Configuration configuration;
        private static readonly ILog log;
        private static ISessionFactory sessionFactory;

        static NHibernateSessionManager()
        {
            log = LogManager.GetLogger(typeof(NHibernateSessionManager));
            ConnectionString = WebConfiguration.ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
        }

        public static Configuration Configuration
        {
            get
            {
                EnsureSessionFactoryHasBeenInitialized();
                return configuration;
            }
        }

        public static string ConnectionString { get; private set; }

        public static ISession CurrentSession
        {
            get
            {
                EnsureSessionFactoryHasBeenInitialized();

                if (HasCurrentlyBoundSession)
                    return sessionFactory.GetCurrentSession();

                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
                return session;
            }
        }

        public static IStatelessSession CurrentStatelessSession
        {
            get
            {
                EnsureSessionFactoryHasBeenInitialized();
                return sessionFactory.OpenStatelessSession();
            }
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                EnsureSessionFactoryHasBeenInitialized();
                return sessionFactory;
            }
        }

        public static void CloseSession()
        {
            if (sessionFactory == null)
                return;

            if (HasCurrentlyBoundSession)
                CloseAndUnbindSessionInstance();
        }

        private static void CloseAndUnbindSessionInstance()
        {
            var session = CurrentSessionContext.Unbind(sessionFactory);
            session.Close();
            log.Debug("session closed");
        }

        /// <summary>
        /// Resets the NHibernate session factory.
        /// <para>This method is provided to simplify testing.</para>
        /// </summary>
        public static void ResetSessionFactory()
        {
            sessionFactory = null;
        }

        private static bool HasCurrentlyBoundSession
        {
            get { return CurrentSessionContext.HasBind(sessionFactory); }
        }

        private static HbmMapping Mapping
        {
            get
            {
                var mapping = ModelMapper.CompileMappingForAllExplicitlyAddedEntities();
                return mapping;
            }
        }

        private static Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().
                   SingleOrDefault(assembly => assembly.GetName().Name == name);
        }

        private static ModelMapper ModelMapper
        {
            get
            {
                Assembly mappingAssembly = GetAssemblyByName("ALaMaronaDAL");
                var modelMapper = new ModelMapper();
                List<Type> exportedTypes = new List<Type>();
                exportedTypes.AddRange(mappingAssembly.GetExportedTypes());
                modelMapper.AddMappings(exportedTypes);
                return modelMapper;
            }
        }

        private static void EnsureSessionFactoryHasBeenInitialized()
        {
            if (sessionFactory == null)
                InitializeSessionFactory();
        }

        private static void ConfigureBatchSize()
        {
            configuration.SetProperty("adonet.batch_size", "1");
        }

        private static void ConfigureDatabase()
        {
            configuration.DataBaseIntegration(db =>
            {
                db.ConnectionString = ConnectionString;
                db.Dialect<MsSql2008Dialect>();
                db.Driver<SqlClientDriver>();
                db.BatchSize = 50;
                db.Timeout = 20;

                //enabled for testing
                db.AutoCommentSql = true;
            });
        }

        private static void ConfigureEventListeners()
        {
            // If you have any event listeners, put them here.
            //new AuditEventListener().Register(configuration);
            //new CustomSaveEventListener().Register(configuration);
        }

        private static void ConfigureMappings()
        {
            configuration.AddMapping(Mapping);
        }

        private static void ConfigureSessionContext<T>() where T : ICurrentSessionContext
        {
            configuration.CurrentSessionContext<T>();
        }

        private static void ConfigureStatistics()
        {
            configuration.SessionFactory().GenerateStatistics();
        }

        private static void InitializeSessionFactory()
        {
            if (HttpContext.Current != null)
                InitializeWebSessionContextSessionFactory();
            else
                InitializeThreadStaticSessionContextSessionFactory();
        }

        private static void InitializeThreadStaticSessionContextSessionFactory()
        {
            sessionFactory = GetSessionFactory<ThreadStaticSessionContext>();
            log.Debug("Created new NHibernate session factory with ThreadStaticSessionContext.");
        }

        private static void InitializeWebSessionContextSessionFactory()
        {
            sessionFactory = GetSessionFactory<WebSessionContext>();
            log.Debug("Created new NHibernate session factory with WebSessionContext.");
        }

        private static ISessionFactory GetSessionFactory<T>() where T : ICurrentSessionContext
        {
            configuration = new Configuration();
            configuration.Configure();
            //ConfigureDatabase();
            //ConfigureSessionContext<T>();
            //ConfigureStatistics();
            //ConfigureMappings();
            //ConfigureEventListeners();
            //ConfigureBatchSize();
            sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory;
        }
    }
}