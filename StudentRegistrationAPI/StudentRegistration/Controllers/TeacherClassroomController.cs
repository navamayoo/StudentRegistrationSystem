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
    public class TeacherClassroomController : ControllerBase
    {
        private readonly ITeacherClassroomRepository repository;

        public TeacherClassroomController(ITeacherClassroomRepository _repository)
        {
            repository = _repository;
        }

        // GET: api/<TeacherClassroomController>
        [HttpGet]
        public IEnumerable<TeacherClassroom> GetAll()
        {
            return repository.GetAllTClassroom().ToList();
        }

        // GET api/<TeacherClassroomController>/5
        [HttpGet("{id}")]
        public TeacherClassroom GetById(int id)
        {
            return repository.GetTClassroomById(id);
        }

        // POST api/<TeacherClassroomController>
        [HttpPost]
        public TeacherClassroom Post([FromBody] TeacherClassroom teacherClassroom)
        {
            return repository.CreateTClassroom(teacherClassroom);
        }

        // PUT api/<TeacherClassroomController>/5
        [HttpPut("{id}")]
        public TeacherClassroom Put(int id, [FromBody] TeacherClassroom teacherClassroom)
        {
            return repository.UpdateTClassroom(teacherClassroom, id);
        }

        // DELETE api/<TeacherClassroomController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteTClassroom(id);    
        }
    }
}
