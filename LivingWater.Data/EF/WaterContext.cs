using LivingWater.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWater.Data.EF
{
    public class WaterContext : DbContext
    {
        public WaterContext() : base() { }
        public WaterContext(string connectionString) : base(connectionString) { } // Вопрос: зачем мы добавляем параметр в конструктор? обязателен ли он?
        public DbSet<Water> Waters { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
    #region Инициализация БД (плюс надо отразить в глобал асакс добавлением строчки Database.SetInitializer(new MyContextDbInitializer());)
    public class MyContextDbInitializer : CreateDatabaseIfNotExists<WaterContext>
    {
        protected override void Seed(WaterContext context)
        {
            Water balsu = new Water { WaterName = "Balsu", ProducerName = "ТОО «Жеті сүт»" };
            Water vodaHrustalnaya = new Water { WaterName = "ВОДА ХРУСТАЛЬНАЯ", ProducerName = "ТОО «Golden Rill Trade»" };
            Water aurasu = new Water { WaterName = "Aurasu", ProducerName = "ИП Абенова К.К." };
            Water ailyn = new Water { WaterName = "Ailyn", ProducerName = "ИП Айлин" };
            context.Waters.AddRange(new List<Water> { balsu, vodaHrustalnaya, aurasu, ailyn });
            context.SaveChanges();
            base.Seed(context);
        }
    }
    #endregion
}
