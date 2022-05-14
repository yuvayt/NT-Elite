using System;
using System.Collections.Generic;

namespace EFStore.Models.DTO
{
    public class ProductDTO : IBaseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public IEnumerable<Guid> CategoryIds { get; set; }
    }
}