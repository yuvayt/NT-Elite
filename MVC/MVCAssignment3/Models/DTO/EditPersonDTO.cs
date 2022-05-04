using System;

namespace MVCAssignment3.Models.DTO
{
    public class EditPersonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public bool IsGraduated { get; set; }
    }
}