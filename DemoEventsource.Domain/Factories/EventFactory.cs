using System;
using DemoEventsource.Domain.Events;

namespace DemoEventsource.Domain.Factories
{
    public interface IEventFactory
    {
    }

    public class EventFactory : IEventFactory
    {
        public static Event<T> Create<T>(Guid streamId, T data)
        {
            return Create(Guid.NewGuid(), streamId, data);
        }

        public static Event<T> Create<T>(Guid eventId, Guid streamId, T data)
        {
            return new Event<T>(eventId, streamId, data);
        }
    }
}
