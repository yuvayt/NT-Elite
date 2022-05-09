using System;
using System.Collections.Generic;
using System.Linq;
using StudentAPI.Models.DTO;
using StudentAPI.Models.Entities;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Services
{
    public class PersonService : IPersonService
    {
        public static List<Person> People;

        public PersonService()
        {
            if (People == null)
            {
                People = InitDummyMembers();
            }
        }
        private static List<Person> InitDummyMembers()
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

        public bool Delete(int id)
        {
            var deletePerson = GetPersonById((int)id);
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

        public IEnumerable<Person> ListPeople(string filterValue)
        {
            if (!string.IsNullOrEmpty(filterValue))
            {
                filterValue = filterValue.Trim();

                return People.Where(
                    p => p.FirstName.Contains(filterValue)
                    || p.LastName.Contains(filterValue)
                    || p.Gender.ToLowerInvariant().Contains(filterValue.ToLowerInvariant())
                    || p.BirthPlace.ToLowerInvariant().Contains(filterValue.ToLowerInvariant()));
            }

            return People.OrderBy(person => person.Id);
        }
    }
}