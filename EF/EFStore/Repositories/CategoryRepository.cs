using EFStore.Contexts;
using EFStore.Models.Entities;
using EFStore.Repositories.Interfaces;

namespace EFStore.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreContext context) : base(context) { }
    }
}