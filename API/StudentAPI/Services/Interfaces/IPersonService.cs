using System;
using System.Collections.Generic;
using StudentAPI.Models.DTO;
using StudentAPI.Models.Entities;

namespace StudentAPI.Services.Interfaces
{
    public interface IPersonService
    {
        Person Create(PersonDTO personDTO);
        Person Update(PersonDTO updatePerson);
        IEnumerable<Person> FilterPeople(SimplifyPersonDTO filterValue);
        Person GetPersonById(Guid id);
        bool Delete(Guid id);
    }
}