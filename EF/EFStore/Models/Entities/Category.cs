using System;
using System.Collections.Generic;

namespace EFStore.Models.Entities
{
    public class Category : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}