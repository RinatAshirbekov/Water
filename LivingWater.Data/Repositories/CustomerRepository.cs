using LivingWater.Data.EF;
using LivingWater.Data.Entities;
using LivingWater.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LivingWater.Data.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private WaterContext _context;
        public CustomerRepository() { }
        public CustomerRepository(WaterContext context) // Вопрос: зачем мы в конструктор передаем параметр? для чего он нужен? и как его используем?
        {
            this._context = context;
        }
        public async Task<Customer> AddAsync(Customer addedCustomer)
        {
            Customer newCustomer = null;
            using (WaterContext waterContext = new WaterContext()) // Вопрос: можем ли мы не использовать using? он нужен для безопасного выхода из подключения?
            {
                newCustomer = waterContext.Customers.Add(addedCustomer);
                await waterContext.SaveChangesAsync();
            }
            return newCustomer;
        }
        public async Task<Customer> GetAsync(int id)
        {
            Customer someCustomer = null;
            using (WaterContext waterContext = new WaterContext())
            {
                someCustomer = await waterContext.Customers.FindAsync(id);
                // someCustomer = await waterContext.Customers.FirstOrDefaultAsync(f=>f.Id == id) ???
                await waterContext.SaveChangesAsync();
            }
            return someCustomer;
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var allCustomers = new List<Customer>();
            using (WaterContext waterContext = new WaterContext())
            {
                allCustomers = await waterContext.Customers.ToListAsync();
            }
            return allCustomers;
            // можно и так: return await waterContext.Customers.ToListAsync();
        }
        public async Task<Customer> UpdateAsync(Customer updatedCustomer)
        {
            using (WaterContext waterContext = new WaterContext())
            {
                waterContext.Entry(updatedCustomer).State = EntityState.Modified;
                await waterContext.SaveChangesAsync();
            }
            return updatedCustomer;
        }
        public async Task DeleteAsync(int id)
        {
            using (WaterContext waterContext = new WaterContext())
            {
                var removableCustomer = await waterContext.Customers.FindAsync(id);
                waterContext.Entry(removableCustomer).State = EntityState.Deleted;
                await waterContext.SaveChangesAsync();
            }
        }
    }
}
