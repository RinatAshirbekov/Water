using LivingWater.Data.EF;
using LivingWater.Data.Entities;
using LivingWater.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWater.Data.Repositories
{
    public class WaterRepository : IRepository<Water>
    {
        private WaterContext _context;
        public WaterRepository() { }
        public WaterRepository(WaterContext context)
        {
            this._context = context;
        }
        public async Task<Water> AddAsync(Water addedWater)
        {
            Water newWater = null;
            using (WaterContext waterContext = new WaterContext())
            {
                newWater = waterContext.Waters.Add(addedWater);
                await waterContext.SaveChangesAsync();
            }
            return newWater;
        }
        public async Task<Water> GetAsync(int id)
        {
            Water someWater = null;
            using (WaterContext waterContext = new WaterContext())
            {
                someWater = await waterContext.Waters.FindAsync(id);
                // someCustomer = await waterContext.Customers.FirstOrDefaultAsync(f=>f.Id == id) ???
                await waterContext.SaveChangesAsync();
            }
            return someWater;
        }
        public async Task<IEnumerable<Water>> GetAllAsync()
        {
            var allWaters = new List<Water>();
            using (WaterContext waterContext = new WaterContext())
            {
                allWaters = await waterContext.Waters.ToListAsync();
            }
            return allWaters;
            // можно и так: return await waterContext.Customers.ToListAsync();
        }
        public async Task<Water> UpdateAsync(Water updatedWater)
        {
            using (WaterContext waterContext = new WaterContext())
            {
                waterContext.Entry(updatedWater).State = EntityState.Modified;
                await waterContext.SaveChangesAsync();
            }
            return updatedWater;
        }
        public async Task DeleteAsync(int id)
        {
            using (WaterContext waterContext = new WaterContext())
            {
                var removableWater = await waterContext.Waters.FindAsync(id);
                waterContext.Entry(removableWater).State = EntityState.Deleted;
                await waterContext.SaveChangesAsync();
            }
        }
    }
}
