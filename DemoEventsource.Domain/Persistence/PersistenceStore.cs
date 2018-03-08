using NEventStore;
using NEventStore.Persistence.Sql.SqlDialects;

namespace DemoEventsource.Domain.Persistence
{
    public interface IPersistenceStore
    {
        IStoreEvents CreateInMemoryConnection();
        IStoreEvents CreateSqlConnection();
    }

    public class PersistenceStore : IPersistenceStore
    {
        public IStoreEvents CreateInMemoryConnection()
        {
            return Wireup.Init()
                .UsingInMemoryPersistence()
                .InitializeStorageEngine()
                .Build();
        }

        public IStoreEvents CreateSqlConnection()
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Initial catalog=NEventStore;Integrated Security=true;";

            return Wireup.Init()
                .UsingSqlPersistence("NEventStore", "system.data.sqlclient", connectionString)
                .WithDialect(new MsSqlDialect())
                .InitializeStorageEngine()
                .UsingJsonSerialization()
                .Build();
        }
    }
}
