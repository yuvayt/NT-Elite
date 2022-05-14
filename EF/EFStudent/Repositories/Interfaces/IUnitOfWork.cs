using System;

namespace EFStudent.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        int SaveChanges();
    }
}