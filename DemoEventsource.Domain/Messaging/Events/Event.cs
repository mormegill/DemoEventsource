using System;

namespace DemoEventsource.Domain.Messaging.Events
{
    public class Event<T>
    {
        public Event(Guid eventId, Guid streamId, T data)
        {
            EventId = eventId;
            StreamId = streamId;
            Data = data;
        }

        public Guid StreamId { get; }
        public Guid EventId { get; }
        public T Data { get; }
    }
}
