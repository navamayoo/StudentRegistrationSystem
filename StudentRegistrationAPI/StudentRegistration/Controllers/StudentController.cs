using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Interface;
using StudentRegistration.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository repository;

        public StudentController(IStudentRepository _repository)
        {
            repository = _repository;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return repository.GetAllStudents().ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return repository.GetStudentById(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public Student Post([FromBody] Student student)
        {
            return repository.CreateStudent(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public Student Put(int id, [FromBody] Student student)
        {
            return repository.UpdateStudent(student, id);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteStudent(id);
        }
    }
}
