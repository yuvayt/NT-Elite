using System;
using System.Collections.Generic;

namespace EFStore.Models.DTO
{
    public class CategoryDTO : IBaseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}