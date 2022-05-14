using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models.DTO;
using StudentAPI.Models.Entities;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("people")]
    public class PersonController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService, IUserService userService)
        {
            _userService = userService;
            _personService = personService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(User loginUser)
        {
            var token = _userService.Authenticate(loginUser);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpPost]
        public Person Create([FromBody] PersonDTO person)
        {
            return _personService.Create(person);
        }

        [HttpPut]
        public Person Edit([FromBody] PersonDTO editPerson)
        {
            return _personService.Update(editPerson);
        }

        [Authorize("Admin")]
        [HttpDelete("{id:Guid}")]
        public bool Delete(Guid id)
        {
            return _personService.Delete(id);
        }

        [HttpGet("/filter-person")]
        public IEnumerable<Person> Get([FromBody] SimplifyPersonDTO filterPerson)
        {
            return _personService.FilterPeople(filterPerson);
        }
    }
}