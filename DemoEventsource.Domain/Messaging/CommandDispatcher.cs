using DemoEventsource.Domain.Messaging.Infrastructure;
using NServiceBus;

namespace DemoEventsource.Domain.Messaging
{
    public interface ICommandDispatcher
    {
        void Send(CommandContext commandContext, params ICommand[] commands);
    }
}
