using System;

namespace EFStore.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        int SaveChanges();
        int SaveChangesWithoutTransaction();
        IDatabaseTransaction BeginTransaction();
    }
}