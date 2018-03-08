using System;

namespace DemoEventsource.Domain.Messaging.Commands
{
    public class Command<T>
    {
        public Command(Guid commandId, Guid streamId, T data)
        {
            CommandId = commandId;
            StreamId = streamId;
            Data = data;
        }

        public Guid StreamId { get; }
        public Guid CommandId { get; }
        public T Data { get; }
    }
}