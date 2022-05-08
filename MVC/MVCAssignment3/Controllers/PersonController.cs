using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCAssignment3.Models.DTO;
using MVCAssignment3.Services.Interfaces;

namespace MVCAssignment3.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult ListPeople()
        {
            var people = _personService.ListPeople();

            if (people == null)
            {
                return null;
            }

            return View(people);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewPersonDTO newPersonDTO)
        {
            var newPerson = _personService.Create(newPersonDTO);

            return RedirectToAction("ListPeople");
        }

        public IActionResult Update(int? id)
        {
            if (id != null)
            {
                var existingPerson = _personService.GetPersonById((int)id);

                if (existingPerson != null)
                {
                    return View(existingPerson);
                }
            }

            return null;
        }

        [HttpPost]
        public IActionResult Update(EditPersonDTO editPersonDTO)
        {
            var updatePerson = _personService.Update(editPersonDTO);

            return RedirectToAction("ListPeople");
        }

        public IActionResult Detail(int? id)
        {
            if (id != null)
            {
                var existingPerson = _personService.GetPersonById((int)id);

                if (existingPerson != null)
                {
                    return View(existingPerson);
                }
            }

            return null;
        }

        public IActionResult Delete(int? id)
        {

            if (id != null)
            {
                var deletePerson = _personService.GetPersonById((int)id);
                if (_personService.Delete(deletePerson))
                {
                    string deleteKey = deletePerson.Id.ToString();
                    HttpContext.Session.SetString(deleteKey, deletePerson.FullName);
                    ViewBag.Id = deleteKey;
                    return View();
                }
            }

            return null;
        }
    }
}