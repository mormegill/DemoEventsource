using NEventStore;

namespace DemoEventsource.Domain.Persistence
{
    public class EventStore
    {
        public static IStoreEvents CreateMemoryConnection()
        {
            return Wireup.Init()
                .UsingInMemoryPersistence()
                .InitializeStorageEngine()
                .Build();
        }
    }
}
