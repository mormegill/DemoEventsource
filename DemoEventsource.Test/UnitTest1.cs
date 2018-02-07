using DemoEventsource.Domain.Factories;
using System;
using System.Data;
using System.Data.SqlClient;
using DemoEventsource.Domain.Events;
using DemoEventsource.Domain.Events.Student;
using DemoEventsource.Domain.Persistence;
using NEventStore;
using Shouldly;
using Xunit;

namespace DemoEventsource.Test
{
    public class UnitTests
    {
        [Fact]
        public void OneEvent_InMemoryStoreTest()
        {
            var streamId = Guid.NewGuid();
            var event1 = EventFactory.Create(streamId, new Created("Apan"));

            using (var store = EventStore.CreateInMemoryConnection())
            {
                using (var stream = store.OpenStream(streamId, 0))
                {
                    stream.Add(new EventMessage { Body = event1.Data });
                    stream.CommitChanges(event1.EventId);
                }

                using (var stream = store.OpenStream(streamId, 0))
                {
                    stream.CommittedEvents.Count.ShouldBe(1);
                }
            }
        }

        [Fact]
        public void TwoSimultaneousEvents_InmemoryStore()
        {
            var streamId = Guid.NewGuid();
            var event1 = EventFactory.Create(streamId, new Created("Apan"));
            var event2 = EventFactory.Create(streamId, new Created("Katten"));

            using (var store = EventStore.CreateInMemoryConnection())
            using (var stream = store.OpenStream(streamId, 0))
            using (var stream2 = store.OpenStream(streamId, 0))
            {
                stream.Add(new EventMessage { Body = event1.Data });
                stream.CommitChanges(event1.EventId);

                stream2.Add(new EventMessage { Body = event2.Data });
                Assert.Throws<ConcurrencyException>(() => stream2.CommitChanges(event2.EventId));
            }
        }

        [Fact]
        public void apa()
        {
            var streamId = Guid.NewGuid();
            var event1 = EventFactory.Create(streamId, new Created("apa1"));

            using (var store = EventStore.CreateSqlConnection())
            using (var stream = store.OpenStream(streamId, 0))
            {
                stream.Add(new EventMessage { Body = event1.Data });
                stream.CommitChanges(event1.EventId);
            }

            using (var connection = new SqlConnection("Server = (localdb)\\MSSQLLocalDB; Initial catalog = NEventStore; Integrated Security = true;"))
                connection.Query("select * from commits where streamIdOriginal = @streamId", new { streamId })
                    .Count().ShouldBe(1);

            using (var store = EventStore.CreateSqlConnection())
            using (var stream = store.OpenStream(streamId, 0))
            {
                stream.CommittedEvents.Count.ShouldBe(1);
            }

        }



    }
}
