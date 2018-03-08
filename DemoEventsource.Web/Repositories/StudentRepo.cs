using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using DemoEventsource.Web.Models;

namespace DemoEventsource.Web.Repositories
{
    public interface IStudentRepo
    {
        Task<Student> GetStudent(Guid studentId);
    }

    public class StudentRepo : IStudentRepo
    {
        private readonly string _connectionString;
        //private IContextFactory _contextFactory;

        public StudentRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Student> GetStudent(Guid studentId)
        {
            return new Student
            {
                Id = studentId,
                Name = "Apa",
                Courses = new List<Course>
                {
                    new Course
                    {
                        Id = Guid.NewGuid(),
                        Title = "Course1",
                        Points = 1
                    },
                    new Course
                    {
                        Id = Guid.NewGuid(),
                        Title = "Course2",
                        Points = 2
                    }
                }
            };
            //var query = @"SELECT * FROM Students WHERE Id = @studentId";
            //using (var db = new SqlConnection(_connectionString))
            //{
            //    var student = await db.QueryFirstOrDefaultAsync<Student>(query, new { studentId });
            //    return student;
            //}
        }
    }
}
