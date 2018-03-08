using System;

namespace DemoEventsource.Domain.Messaging.Events.Student
{
    public class Enrolled
    {
        public Enrolled(Guid courseId, DateTime startDate )
        {
            CourseId = courseId;
            StartDate = startDate;
        }

        public DateTime StartDate { get; }
        public Guid CourseId { get; }
    }
}