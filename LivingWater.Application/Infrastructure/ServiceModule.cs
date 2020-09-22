using LivingWater.Data.Interfaces;
using LivingWater.Data.Repositories;
using LivingWater.Data.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWater.Application.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IUnitOfWork>().To<UnitOfWork>(); 
            Bind<ICustomerService>().To<CustomerService>(); // я использовал ninject и в LivingWater.Web в папке Util в классе OrderModule, в каком проекте лучше все это реализовывать?
        }
    }
}
