using System;

namespace DemoEventsource.Web.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public int Points { get; set; }
        public Course ParentCourse { get; set; }
    }
}