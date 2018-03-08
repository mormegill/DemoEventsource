using System;
using System.Collections.Generic;

namespace DemoEventsource.Web.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
