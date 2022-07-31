using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Data;
using StudentRegistration.Interface;
using StudentRegistration.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomRepository repository;

        public ClassroomController(IClassroomRepository _repository)
        {
            repository = _repository;
        }
        // GET: api/<ClassroomController>
        [HttpGet]
        public IEnumerable<Classroom> GetAll()
        {
            return repository.GetAllClassrooms().ToList();
        }

        // GET api/<ClassroomController>/5
        [HttpGet("{id}")]
        public Classroom GetById(int id)
        {
            return repository.GetClassroomById(id); 
        }

        // POST api/<ClassroomController>
        [HttpPost]
        public Classroom Post([FromBody] Classroom classroom)
        {
            return repository.CreateClassroom(classroom);
        }

        // PUT api/<ClassroomController>/5
        [HttpPut("{id}")]
        public Classroom Put([FromBody] Classroom classroom)
        {
            return repository.UpdateClassroom(classroom);
        }

        // DELETE api/<ClassroomController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteClassroom(id); 
        }
    }
}
