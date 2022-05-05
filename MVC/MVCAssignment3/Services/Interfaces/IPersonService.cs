using System.Collections.Generic;
using MVCAssignment3.Models.DTO;
using MVCAssignment3.Models.Entities;

namespace MVCAssignment3.Services.Interfaces
{
    public interface IPersonService
    {
        Person Create(NewPersonDTO personDTO);
        Person Update(EditPersonDTO editPersonDTO);
        IEnumerable<Person> ListPeople();
        Person GetPersonById(int id);
        bool Delete(Person deletePerson);
    }
}