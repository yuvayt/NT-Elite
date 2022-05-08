using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCAssignment3.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Gender { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime Dob { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Birth Place")]
        public string BirthPlace { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - this.Dob.Year;
            }
        }

        [DisplayName("Graduated")]
        public bool IsGraduated { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

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