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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository repository;

        public TeacherController(ITeacherRepository _repository)
        {
            repository = _repository;
        }
        // GET: api/<TeacherController>
        [HttpGet]
        public IEnumerable<Teacher> GetAll()
        {
            return repository.GetAllTeachers().ToList();
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public Teacher GetById(int id)
        {
            return repository.GetTeacherById(id);
        }

        // POST api/<TeacherController>
        [HttpPost]
        public Teacher Post([FromBody] Teacher teacher)
        {
            return repository.CreateTeacher(teacher);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public Teacher Put(int id, [FromBody] Teacher teacher)
        {
            return repository.UpdateTeacher(teacher, id);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteTeacher(id);
        }
    }
}
