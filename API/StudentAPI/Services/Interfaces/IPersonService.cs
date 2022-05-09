using System.Collections.Generic;
using StudentAPI.Models.DTO;
using StudentAPI.Models.Entities;

namespace StudentAPI.Services.Interfaces
{
    public interface IPersonService
    {
        Person Create(NewPersonDTO personDTO);
        Person Update(EditPersonDTO editPersonDTO);
        IEnumerable<Person> ListPeople(string filterValue);
        Person GetPersonById(int id);
        bool Delete(int id);
    }
}