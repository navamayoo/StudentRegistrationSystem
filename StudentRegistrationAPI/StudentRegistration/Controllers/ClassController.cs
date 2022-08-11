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
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository repository;

        public ClassController(IClassRepository _repository)
        {
            repository = _repository;
        }
        // GET: api/<ClassController>
        [HttpGet]
        public IEnumerable<Class> GetAll()
        {
            return repository.GetAllClasses().ToList();
        }

        // GET api/<ClassController>/5
        [HttpGet("{id}")]
        public Class GetById(int id)
        {
            return repository.GetClassById(id); 
        }

        // POST api/<ClassController>
        [HttpPost]
        public Class Post([FromBody] Class Class)
        {
            return repository.CreateClass(Class);
        }

        // PUT api/<ClassController>/5
        [HttpPut("{id}")]
        public Class Put([FromBody] Class Class)
        {
            return repository.UpdateClass(Class);
        }

        // DELETE api/<ClassController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteClass(id); 
        }
    }
}
