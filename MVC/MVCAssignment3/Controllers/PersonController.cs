using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCAssignment3.Models.DTO;
using MVCAssignment3.Services.Interfaces;

namespace MVCAssignment3.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(NewPersonDTO newPersonDTO)
        {
            var newPerson = _personService.Create(newPersonDTO);
            return View(newPerson);
        }

        public IActionResult Edit(EditPersonDTO editPersonDTO)
        {
            var updatePerson = _personService.Edit(editPersonDTO);
            return View(updatePerson);
        }
    }
}