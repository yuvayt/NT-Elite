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
        private static List<Person> _people;

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
            private set
            {
                _people = value;
            }
        }
        public PersonService()
        {
            if (_people == null)
            {
                _people = InitDummyMembers();
            }
        }
        private List<Person> InitDummyMembers()
        {
            return new List<Person>{
             new Person(1, "Bo", "Tran", "Bio", new DateTime(2021, 6, 9), "01234435", "HCM", false),
             new Person(2, "Da", "Nguyen", "Male", new DateTime(1969, 6, 9), "01234435", "HN", true),
             new Person(3, "Banh", "Kha", "Male", new DateTime(2000, 6, 9), "01234435", "HCM", false),
             new Person(4, "Huan", "Rose", "Female", new DateTime(1999, 6, 8), "01234435", "HCM", true),
             new Person(5, "Tien", "Bip", "Male", new DateTime(2001, 6, 9), "01234435", "HN", true),
             new Person(6, "Loc", "Fuho", "Male", new DateTime(2001, 6, 9), "01234435", "DN", true)
            };
        }

        public Person Create(NewPersonDTO personDTO)
        {
            int? maxId = People.Max(p => p.Id);
            if (maxId == null)
            {
                maxId = 0;
            }
            var nextId = (int)maxId + 1;

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

        public bool Delete(Person deletePerson)
        {

            if (deletePerson != null)
            {
                People.Remove(deletePerson);
                return true;
            }

            return false;
        }

        public Person Update(EditPersonDTO editPersonDTO)
        {
            var existingPerson = GetPersonById(editPersonDTO.Id);
            if (existingPerson != null)
            {
                existingPerson.FirstName = editPersonDTO.FirstName;
                existingPerson.LastName = editPersonDTO.LastName;
                existingPerson.Gender = editPersonDTO.Gender;
                existingPerson.Dob = editPersonDTO.Dob;
                existingPerson.PhoneNumber = editPersonDTO.PhoneNumber;
                existingPerson.BirthPlace = editPersonDTO.BirthPlace;
                existingPerson.IsGraduated = editPersonDTO.IsGraduated;

                return existingPerson;
            }

            return null;
        }

        public Person GetPersonById(int id)
        {
            return People.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> ListPeople()
        {
            return People.OrderBy(person => person.Id);
        }
    }
}