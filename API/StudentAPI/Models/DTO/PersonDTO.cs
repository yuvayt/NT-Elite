using System;

namespace StudentAPI.Models.DTO
{
    public class PersonDTO : SimplifyPersonDTO
    {
        public Guid Id { get; set; }
        public DateTime Dob { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsGraduated { get; set; }
    }
}