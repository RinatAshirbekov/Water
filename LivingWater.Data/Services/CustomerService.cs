using LivingWater.Data.Entities;
using LivingWater.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWater.Data.Services
{
    public class CustomerService : ICustomerService // Вопрос: зачем мы создали сервис, когда мы можем через репозиторий обращаться к БД, в чем смысл? 
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Water> _waterRepository;

        public CustomerService(IRepository<Customer> customerRepository, IRepository<Water> waterRepository)
        {
            _customerRepository = customerRepository;
            _waterRepository = waterRepository;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            return await _customerRepository.AddAsync(customer);
        }
        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _customerRepository.GetAsync(id);
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }
        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            return await _customerRepository.UpdateAsync(customer);
        }

        public async Task<IEnumerable<Water>> GetWaters()
        {
            return await _waterRepository.GetAllAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }  
    }
}
