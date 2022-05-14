using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFStudent.Models.Entities;
using EFStudent.Models.DTO;

namespace EFStudent.Extensions
{
    public static class StudentExtensions
    {
        public static Student DtoToEntity(this StudentDTO dto)
        {
            return new Student
            {
                Id = dto.Id,
                Firstname = dto.Firstname,
                LastName = dto.LastName,
                City = dto.City,
                State = dto.State,
            };
        }

        public static StudentDTO EntityToDto(this Student entity)
        {
            return new StudentDTO
            {
                Id = entity.Id,
                Firstname = entity.Firstname,
                LastName = entity.LastName,
                City = entity.City,
                State = entity.State,
            };
        }
    }
}