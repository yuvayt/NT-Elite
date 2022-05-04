using System;

namespace MVCAssignment3.Models.Entities
{
    public class Person
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - this.Dob.Year;
            }
        }
        public bool IsGraduated { get; set; }

        public Person(
            int id, string firstName, string lastName, string gender,
            DateTime dob, string phoneNumber, string birthPlace,
            bool isGraduated)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Dob = dob;
            this.PhoneNumber = phoneNumber;
            this.BirthPlace = birthPlace;
            this.IsGraduated = isGraduated;
        }
    }
}