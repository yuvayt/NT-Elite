using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFStudent.Models.Entities
{
    public class Student : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}