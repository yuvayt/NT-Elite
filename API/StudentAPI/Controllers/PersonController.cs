using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models.DTO;
using StudentAPI.Models.Entities;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("people")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public Person Create([FromBody] NewPersonDTO newPerson)
        {
            return _personService.Create(newPerson);
        }

        [HttpPut]
        public Person Edit([FromBody] EditPersonDTO editPerson)
        {
            return _personService.Update(editPerson);
        }

        [HttpDelete("{id:int}")]
        public bool Delete(int id)
        {
            return _personService.Delete(id);
        }

        [HttpGet]
        public IEnumerable<Person> Get(string filterValue)
        {
            return _personService.ListPeople(filterValue);
        }
    }
}