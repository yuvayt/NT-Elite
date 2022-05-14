using EFStudent.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFStudent.Contexts
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}