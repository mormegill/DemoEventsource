namespace DemoEventsource.Domain.Messaging.Infrastructure
{
    public class CommandContext
    {
        public string UserName { get; private set; }
        public string MachineName { get; private set; }

        public CommandContext(string userName, string machineName)
        {
            UserName = userName;
            MachineName = machineName;
        }
    }
}
