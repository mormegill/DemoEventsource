using System;
using DemoEventsource.Domain.Messaging.Commands;

namespace DemoEventsource.Domain.Factories
{
    public interface ICommandFactory { }

    public class CommandFactory : ICommandFactory
    {
        public static Command<T> Create<T>(Guid streamId, T data)
        {
            return Create(Guid.NewGuid(), streamId, data);
        }

        public static Command<T> Create<T>(Guid commandId, Guid streamId, T data)
        {
            return new Command<T>(commandId, streamId, data);
        }
    }
}