using System;
using System.Collections.Generic;
using System.Linq;
using MVCAssignment3.Models.DTO;
using MVCAssignment3.Models.Entities;
using MVCAssignment3.Services.Interfaces;

namespace MVCAssignment3.Services
{
    public class PersonService : IPersonService
    {
        private List<Person> _people;

        public List<Person> People
        {
            get
            {
                if (_people != null)
                {
                    return _people;
                }
                else
                {
                    return InitDummyMembers();
                }
            }
        }
        public PersonService()
        {
            _people = InitDummyMembers();
        }
        private List<Person> InitDummyMembers()
        {
            return new List<Person>{
             new Person(1, "Bo", "Tran", "Bio", new DateTime(2021, 6, 9), "01234435", "HCM", false),
             new Person(2, "Da", "Nguyen", "Male", new DateTime(1969, 6, 9), "01234435", "HN", true),
             new Person(3, "Banh", "Kha", "Male", new DateTime(2000, 6, 9), "01234435", "HCM", false),
             new Person(4, "Huan", "Rose", "Male", new DateTime(1999, 6, 8), "01234435", "HCM", true),
             new Person(5, "Tien", "Bip", "Male", new DateTime(2001, 6, 9), "01234435", "HN", true)
            };
        }

        public Person Create(NewPersonDTO personDTO)
        {
            //Todo: handle to get next id
            var nextId = 1;
            var addingPerson = new Person(
            nextId
            , personDTO.FirstName
            , personDTO.LastName
            , personDTO.Gender
            , personDTO.Dob
            , personDTO.PhoneNumber
            , personDTO.BirthPlace
            , personDTO.IsGraduated);

            People.Add(addingPerson);

            return addingPerson;
        }

        public bool Delete()
        {
            return false;
        }

        public Person Edit(EditPersonDTO editPersonDTO)
        {
            var existingPerson = People.FirstOrDefault(p => p.Id == editPersonDTO.Id);
            if (existingPerson != null)
            {
                existingPerson.FirstName = editPersonDTO.FirstName;

                return existingPerson;
            }

            return null;
        }

        public Person GetPersonById(int id)
        {
            return null;
        }

        public List<Person> ListAll()
        {
            return null;
        }
    }
}