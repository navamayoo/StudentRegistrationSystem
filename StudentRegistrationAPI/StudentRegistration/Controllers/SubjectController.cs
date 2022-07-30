using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Models;
using SubjectRegistration.Interface;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository repository;

        public SubjectController(ISubjectRepository _repository)
        {
            repository = _repository;
        }
        // GET: api/<SubjectController>
        [HttpGet]
        public IEnumerable<Subject> Get()
        {
            return repository.GetAllSubjects().ToList();
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public Subject Get(int id)
        {
            return repository.GetSubjectById(id);
        }

        // POST api/<SubjectController>
        [HttpPost]
        public Subject Post([FromBody] Subject subject)
        {
            return repository.CreateSubject(subject);
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public Subject Put(int id, [FromBody] Subject subject)
        {
            return repository.UpdateSubject(subject, id);
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteSubject(id);
        }
    }
}
