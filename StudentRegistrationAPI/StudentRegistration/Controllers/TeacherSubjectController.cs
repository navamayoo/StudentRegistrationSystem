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
    public class TeacherSubjectController : ControllerBase
    {
        private readonly ITeacherSubjectRepository repository;

        public TeacherSubjectController(ITeacherSubjectRepository _repository)
        {
            repository = _repository;
        }

        // GET: api/<TeacherSubjectController>
        [HttpGet]
        public IEnumerable<TeacherSubject> GetAll()
        {
            return repository.GetAllTSubjects().ToList();
        }

        // GET api/<TeacherSubjectController>/5
        [HttpGet("{id}")]
        public TeacherSubject GetById(int id)
        {
            return repository.GetTSubjectById(id);
        }

        // POST api/<TeacherSubjectController>
        [HttpPost]
        public TeacherSubject Post([FromBody] TeacherSubject teacherSubject)
        {
            return repository.CreateTSubject(teacherSubject);
        }

        // PUT api/<TeacherSubjectController>/5
        [HttpPut("{id}")]
        public TeacherSubject Put(int id, [FromBody] TeacherSubject teacherSubject)
        {
            return repository.UpdateTSubject(teacherSubject, id);
        }

        // DELETE api/<TeacherSubjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteTSubject(id);
        }
    }
}
