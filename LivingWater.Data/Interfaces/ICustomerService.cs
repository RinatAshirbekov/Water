using LivingWater.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWater.Data.Interfaces
{
    public interface ICustomerService
    {
        // сигнатура методов, которые будут реализованы с помощью
        // конкретного класса реализации в данно случае CustomerService
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task DeleteCustomerAsync(int id);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<IEnumerable<Water>> GetWaters();
    }
}
