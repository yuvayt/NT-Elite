using System;
using System.Collections.Generic;
using EFStore.Models.DTO;

namespace EFStore.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        T Add(T dto);
        T GetById(Guid id);
        IEnumerable<T> GetAll(FilterParameters parameters);
        bool Remove(Guid id);
        T Update(T dto);
    }
}