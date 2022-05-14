using EFStore.Contexts;
using EFStore.Models.Entities;
using EFStore.Repositories.Interfaces;

namespace EFStore.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreContext context) : base(context) { }
    }
}