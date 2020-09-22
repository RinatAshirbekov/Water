using LivingWater.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWater.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Water> Waters { get; }
        IRepository<Customer> Customers { get; }
        Task SaveAsync();
    }
}
