using System;

namespace EFStore.Models.DTO
{
    public interface IBaseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}