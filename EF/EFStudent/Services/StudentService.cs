using System;
using System.Collections.Generic;
using System.Linq;
using EFStudent.Extensions;
using EFStudent.Models.DTO;
using EFStudent.Models.Entities;
using EFStudent.Repositories.Interfaces;
using EFStudent.Services.Interfaces;

namespace EFStudent.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public StudentDTO Add(StudentDTO dto)
        {
            var student = _unitOfWork.Students.Add(dto.DtoToEntity());
            _unitOfWork.SaveChanges();

            return student.EntityToDto();
        }

        public IEnumerable<StudentDTO> GetAll(OwnerParameters parameters)
        {
            var students = _unitOfWork.Students.GetAll();
            var searchString = parameters.SearchString;
            var sortOrder = parameters.SortOrder;
            var pageSize = parameters.PageSize;
            var pageNumber = parameters.PageNumber;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString)
                                       || s.Firstname.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "first_name_desc":
                    students = students.OrderByDescending(s => s.Firstname);
                    break;
                case "last_name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "city":
                    students = students.OrderBy(s => s.City);
                    break;
                case "city_desc":
                    students = students.OrderByDescending(s => s.City);
                    break;
                default:  // Name ascending 
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            return students
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize)
                   .Select(x => x.EntityToDto());
        }

        public StudentDTO GetById(Guid id)
        {
            var existingStudent = _unitOfWork.Students.GetById(id);
            if (existingStudent == null)
            {
                return null;
            }
            return existingStudent.EntityToDto();
        }

        public bool Remove(Guid id)
        {
            var deleteStudent = _unitOfWork.Students.GetById(id);
            if (deleteStudent == null)
            {
                return false;
            }
            _unitOfWork.Students.Remove(deleteStudent);
            _unitOfWork.SaveChanges();

            return true;
        }

        public StudentDTO Update(StudentDTO dto)
        {
            var id = dto.Id;
            var updateStudent = _unitOfWork.Students.GetById(id);
            if (updateStudent == null)
            {
                return null;
            }

            updateStudent.Id = id;
            updateStudent.Firstname = dto.Firstname;
            updateStudent.LastName = dto.LastName;
            updateStudent.City = dto.City;
            updateStudent.State = dto.State;

            _unitOfWork.SaveChanges();

            return updateStudent.EntityToDto();
        }
    }
}