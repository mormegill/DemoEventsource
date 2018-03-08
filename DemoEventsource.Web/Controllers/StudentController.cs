using System;
using System.Threading.Tasks;
using DemoEventsource.Domain.Messaging.Commands.Student;
using DemoEventsource.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoEventsource.Web.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepo _studentRepository;

        public StudentController(IStudentRepo studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost]
        public IActionResult Post(Guid studentId)
        {
            var command = new CreateStudentCommand(studentId);
            commandDispatcher.Send(base.CommandContext, command);

        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid studentId)
        {
            var student = _studentRepository.GetStudent(studentId);
            if (student != null)
            {
                return Ok(student);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
