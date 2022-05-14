using System;

namespace EFStore.Models.Entities
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}