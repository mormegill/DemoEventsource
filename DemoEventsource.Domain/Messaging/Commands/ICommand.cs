using System;

namespace DemoEventsource.Domain.Messaging.Commands
{
    public interface ICommand
    {
        Guid CommandId { get; }
    }
}