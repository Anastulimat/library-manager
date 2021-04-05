using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.IO;

namespace Persistance
{
    public class ORM<T>
    {
        static readonly string FileDB = "MyData.db";
    
        public static ISessionFactory CreateSessionFactory(bool testing=false)
        {
            if(testing)
                return CreateSessionFactory(BuildSchemaAlways);
            else
                return CreateSessionFactory(BuildSchemaIfFileIsMissing);
        }

        static ISessionFactory CreateSessionFactory(Action<Configuration> BuildSchema)
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(FileDB))
                .Mappings(m => m.AutoMappings.Add(CreateAutomappings))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        static AutoPersistenceModel CreateAutomappings()
        {
            return AutoMap.AssemblyOf<T>()
                .Where(type => type.Namespace == "Domaine")
                .Conventions.Add(
                    DefaultCascade.All(),
                    DefaultLazy.Always()
                 );
        }

        static void BuildSchemaIfFileIsMissing(Configuration config)
        {
            if (!File.Exists(FileDB))
                new SchemaExport(config).Create(false, true);
        }

        static void BuildSchemaAlways(Configuration config)
        {
            if (File.Exists(FileDB))
                File.Delete(FileDB);
            new SchemaExport(config).Create(false, true);
        }
    }
}
