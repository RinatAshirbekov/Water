using LivingWater.Data.EF;
using LivingWater.Data.Entities;
using LivingWater.Data.Interfaces;
using LivingWater.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWater.Data.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private WaterContext _context;
        private WaterRepository _waterRepository;
        private CustomerRepository _customerRepository;
        public UnitOfWork() { }
        public UnitOfWork(string connectionString)
        {
            _context = new WaterContext(connectionString);
        }
        public IRepository<Water> Waters
        {
            get 
            {
                if (_waterRepository == null)
                    _waterRepository = new WaterRepository(); // если не получится запустить попробовать без конструктора
                return _waterRepository;
            }
        }
        public IRepository<Customer> Customers
        {
            get 
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository();
                return _customerRepository;
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
