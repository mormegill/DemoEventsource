namespace DemoEventsource.Domain.Events.Student
{
    public class Created
    {
        public Created(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
