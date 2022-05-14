using System;
using System.Collections.Generic;
using EFStudent.Models.DTO;
using EFStudent.Models.Entities;
using EFStudent.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFStudent.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController
    {
        public IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("/create-student")]
        public StudentDTO Create([FromBody] StudentDTO newStudent)
        {
            return _studentService.Add(newStudent);
        }

        [HttpGet("/get-student")]
        public StudentDTO Get(Guid id)
        {
            return _studentService.GetById(id);
        }

        [HttpGet("/get-all")]
        public IEnumerable<StudentDTO> People([FromQuery] OwnerParameters ownerParameters)
        {
            return _studentService.GetAll(ownerParameters);
        }

        [HttpDelete("/delete-student")]
        public bool Delete(Guid id)
        {
            return _studentService.Remove(id);
        }

        [HttpPut("/update-student")]
        public StudentDTO Update(StudentDTO studentDTO)
        {
            return _studentService.Update(studentDTO);
        }
    }
}