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
    public class TeacherClassController : ControllerBase
    {
        private readonly ITeacherClassRepository repository;

        public TeacherClassController(ITeacherClassRepository _repository)
        {
            repository = _repository;
        }

        // GET: api/<TeacherClassroomController>
        [HttpGet]
        public IEnumerable<TeacherClass> GetAll()
        {
            return repository.GetAllTeacherClass().ToList();
        }

        // GET api/<TeacherClassroomController>/5
        [HttpGet("{id}")]
        public TeacherClass GetById(int id)
        {
            return repository.GetTeacherClassById(id);
        }

        // POST api/<TeacherClassroomController>
        [HttpPost]
        public TeacherClass Post([FromBody] TeacherClass teacherClassroom)
        {
            return repository.CreateTeacherClass(teacherClassroom);
        }

        // PUT api/<TeacherClassroomController>/5
        [HttpPut("{id}")]
        public TeacherClass Put(int id, [FromBody] TeacherClass teacherClassroom)
        {
            return repository.UpdateTeacherClass(teacherClassroom, id);
        }

        // DELETE api/<TeacherClassroomController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteTeacherClass(id);    
        }
    }
}
