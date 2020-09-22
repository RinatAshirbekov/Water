using LivingWater.Data.Entities;
using LivingWater.Data.Interfaces;
using LivingWater.Data.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LivingWater.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Customer>>().To<CustomerRepository>();
            Bind<IRepository<Water>>().To<WaterRepository>();
        }
    }
}