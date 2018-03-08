using System;

namespace DemoEventsource.Domain.Messaging.Commands.Student
{
    public class CreateStudentCommand : ICommand
    {
        public CreateStudentCommand(Guid id)
        {
            Id = id;
            CommandId = Guid.NewGuid();
        }

        public Guid Id { get; }
        public Guid CommandId { get; }
    }
}
