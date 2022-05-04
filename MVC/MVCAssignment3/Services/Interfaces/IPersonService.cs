using System.Collections.Generic;
using MVCAssignment3.Models.DTO;
using MVCAssignment3.Models.Entities;

namespace MVCAssignment3.Services.Interfaces
{
    public interface IPersonService
    {
        Person Create(NewPersonDTO personDTO);
        Person Edit(EditPersonDTO editPersonDTO);
        List<Person> ListAll();
        Person GetPersonById(int id);
        bool Delete();
    }
}