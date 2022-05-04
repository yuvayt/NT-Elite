using System;

namespace MVCAssignment2.Models
{
    public class Member
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
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}",
                this.LastName, this.FirstName);
            }
        }
        public string FullInfo
        {
            get
            {
                return string.Format(
                    "First Name: {0}\r\n"
                    + "LastName: {1} \r\n"
                    + "Gender: {2} \r\n"
                    + "Date Of Birth: {3} \r\n"
                    + "Phone Number: {4} \r\n"
                    + "Birth Place: {5} \r\n"
                    + "Age: {6} \r\n"
                    + "Is Graduated: {7}",
                    this.FirstName,
                    this.LastName,
                    this.Gender,
                    this.Dob,
                    this.PhoneNumber,
                    this.BirthPlace,
                    this.Age,
                    this.IsGraduated
                );
            }
        }

        public Member()
        {

        }

        public Member(
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