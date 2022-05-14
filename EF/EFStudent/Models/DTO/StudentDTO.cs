using System;

namespace EFStudent.Models.DTO
{
    public class StudentDTO : IBaseDTO
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}