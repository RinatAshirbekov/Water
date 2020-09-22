using LivingWater.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWater.Data.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        Task<T> AddAsync(T item);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> UpdateAsync(T item);
        Task DeleteAsync(int id);
    }
}
