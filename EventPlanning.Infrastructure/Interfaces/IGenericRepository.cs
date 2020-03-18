using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanning.Infrastructure.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> Create(T t);
        Task Delete(T t);
        Task Update(T t);
        Task<T> Get(Guid id);
        Task<IList<T>> GetAll();
    }
}
