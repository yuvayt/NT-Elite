using System;

namespace AssignmentDay1
{
    public class Member
    {
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

        public Member(string firstName, string ln, string g, DateTime dob, string pn, string bp, bool ig)
        {
            this.FirstName = firstName;
            this.LastName = ln;
            this.Gender = g;
            this.Dob = dob;
            this.PhoneNumber = pn;
            this.BirthPlace = bp;
            this.IsGraduated = ig;
        }

        public string GetFullName()
        {
            return string.Format("{0} {1}", this.LastName, this.FirstName);
        }
    }
}