using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Mappings;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Utils
{
    public class NHibernateHelper
    {
        private static ISessionFactory? _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory =
                        Fluently
                        .Configure()
                        .Database(
                            SQLiteConfiguration.Standard
                            .ConnectionString("Data Source=yourdatabase.db")
                        )
                        .Mappings(m =>
                        {
                            m.FluentMappings.AddFromAssemblyOf<AuthorMap>();
                            m.FluentMappings.AddFromAssemblyOf<BookMap>();
                        })
                        .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, true))
                        .BuildSessionFactory();
                }
                return _sessionFactory!;
            }
        }

        public static NHibernate.ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}