using System;
using System.Collections.Generic;
using EFStudent.Models.DTO;
using EFStudent.Models.Entities;

namespace EFStudent.Services.Interfaces
{
    public interface IStudentService
    {
        StudentDTO Add(StudentDTO entity);
        StudentDTO GetById(Guid id);
        IEnumerable<StudentDTO> GetAll(OwnerParameters parameters);
        bool Remove(Guid id);
        StudentDTO Update(StudentDTO studentDTO);
    }
}