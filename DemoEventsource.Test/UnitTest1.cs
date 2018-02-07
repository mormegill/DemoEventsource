using DemoEventsource.Domain.Factories;
using System;
using DemoEventsource.Domain.Events.Student;
using DemoEventsource.Domain.Persistence;
using NEventStore;
using Shouldly;
using Xunit;

namespace DemoEventsource.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var streamId = Guid.NewGuid();
            var event1 = EvsentFactory.Create(streamId, new Created("Apan"));

            using (var store = EventStore.CreateMemoryConnection())
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
    }
}
