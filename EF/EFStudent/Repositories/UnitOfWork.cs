using EFStudent.Contexts;
using EFStudent.Repositories.Interfaces;

namespace EFStudent.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentContext _context;
        public UnitOfWork(StudentContext context)
        {
            _context = context;
            Students = new StudentRepository(_context);
        }

        public IStudentRepository Students { get; private set; }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}