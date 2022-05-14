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
             new Person("Bo", "Tran", "Bio", new DateTime(2021, 6, 9), "01234435", "HCM", false),
             new Person("Da", "Nguyen", "Male", new DateTime(1969, 6, 9), "01234435", "HN", true),
             new Person("Banh", "Kha", "Male", new DateTime(2000, 6, 9), "01234435", "HCM", false),
             new Person("Huan", "Rose", "Female", new DateTime(1999, 6, 8), "01234435", "HCM", true),
             new Person("Tien", "Bip", "Male", new DateTime(2001, 6, 9), "01234435", "HN", true),
             new Person("Loc", "Fuho", "Male", new DateTime(2001, 6, 9), "01234435", "DN", true)
            };
        }

        public Person Create(PersonDTO personDTO)
        {
            var addingPerson = new Person(
             personDTO.FirstName
            , personDTO.LastName
            , personDTO.Gender
            , personDTO.Dob
            , personDTO.PhoneNumber
            , personDTO.BirthPlace
            , personDTO.IsGraduated);

            People.Add(addingPerson);

            return addingPerson;
        }

        public bool Delete(Guid id)
        {
            var deletePerson = GetPersonById(id);
            if (deletePerson != null)
            {
                People.Remove(deletePerson);

                return true;
            }

            return false;
        }

        public Person Update(PersonDTO updatePerson)
        {
            if (updatePerson == null || updatePerson.Id == Guid.Empty)
            {
                return null;
            }

            var existingPerson = GetPersonById(updatePerson.Id);
            if (existingPerson == null)
            {
                return null;
            }

            existingPerson.FirstName = updatePerson.FirstName;
            existingPerson.LastName = updatePerson.LastName;
            existingPerson.Gender = updatePerson.Gender;
            existingPerson.Dob = updatePerson.Dob;
            existingPerson.PhoneNumber = updatePerson.PhoneNumber;
            existingPerson.BirthPlace = updatePerson.BirthPlace;
            existingPerson.IsGraduated = updatePerson.IsGraduated;

            return existingPerson;
        }

        public Person GetPersonById(Guid id)
        {
            return People.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> FilterPeople(SimplifyPersonDTO filerDto)
        {
            if (filerDto == null)
            {
                return null;
            }

            return People.Where(
                p =>
                   p.FirstName == filerDto.FirstName
                || p.LastName == filerDto.LastName
                || (!string.IsNullOrEmpty(filerDto.Gender) && p.Gender.ToLower() == filerDto.Gender.ToLower())
                || (!string.IsNullOrEmpty(filerDto.BirthPlace) && p.BirthPlace.ToLower() == filerDto.BirthPlace.ToLower()));
        }
    }
}