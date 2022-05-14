using EFStudent.Contexts;
using EFStudent.Models.Entities;
using EFStudent.Repositories.Interfaces;

namespace EFStudent.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentContext context) : base(context)
        {
        }
    }
}