using NEventStore;
using NEventStore.Persistence.Sql;
using NEventStore.Persistence.Sql.SqlDialects;

namespace DemoEventsource.Domain.Persistence
{
    public class EventStore
    {
        public static IStoreEvents CreateInMemoryConnection()
        {
            return Wireup.Init()
                .UsingInMemoryPersistence()
                .InitializeStorageEngine()
                .Build();
        }

        public static IStoreEvents CreateSqlConnection()
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Initial catalog=NEventStore;Integrated Security=true;";

            var config = new ConfigurationConnectionFactory(
                    "NEventStorePoc", "system.data.sqlclient", connectionString);

            return Wireup.Init()
                .UsingSqlPersistence(config)
                .WithDialect(new MsSqlDialect())
                .InitializeStorageEngine()
                .Build();
        }
    }
}
