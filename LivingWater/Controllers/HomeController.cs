using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LivingWater.Data.EF;
using LivingWater.Data.Entities;
using LivingWater.Data.Interfaces;
using LivingWater.Data.Repositories;
using System.Threading.Tasks;
using LivingWater.Data.Services;

namespace LivingWater.Controllers
{
    public class HomeController : Controller
    {
        // я пробовал использовать UnitOfWork, который я пока исключил из проекта, у меня не получалось, как это реализовать?
        private readonly ICustomerService _customerService;
        private readonly WaterContext _waterContext;
        public HomeController(ICustomerService customerService) // Вопрос: почему мы в конструктор передаем наш сервис, можно ли не передавать? или мы тем самым в конструкторе инициализируем данный сервис и контекст БД?
        {
            _customerService = customerService;
            _waterContext = new WaterContext("WaterContext");
        }
        public async Task<ActionResult> Index()
        {
            var customers = await _customerService.GetAllCustomersAsync(); //AZAMAT: раскомментировал, работает всё. Ты уже настроил, контекст здесь уже не нужен
            //var customers = _waterContext.Customers.Include(f => f.Water);
            return View(customers);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Мои контакты:";
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> MakeOrder()
        {
            #region До использования UnitOfWork
            //// передаем список всех производителей воды
            //SelectList waters = new SelectList(db.Waters, "Id", "WaterName");
            //ViewBag.Waters = waters;
            //return View();
            #endregion
            // передаем список всех производителей воды
            //SelectList waters = new SelectList(_waterContext.Waters, "Id", "WaterName"); // Вопрос: почему не получается через сервис это сделать? и как это сделать через сервис?
            //ViewBag.Waters = waters; // Продолжение вопроса: таким образом не получается - SelectList waters = new SelectList(_customerService.Waters, "Id", "WaterName") как сделать через сервис селект лист?

            SelectList waters = new SelectList(await _customerService.GetWaters(), "Id", "WaterName"); //сделал через сервис, ничего сложного, всё также
            ViewBag.Waters = waters;

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> MakeOrder(Customer customer)
        {
            #region До использования UnitOfWork
            //SelectList waters = new SelectList(db.Waters, "Id", "WaterName");
            //ViewBag.Waters = waters;
            //if (ModelState.IsValid)
            //{
            //    // добавляем информацию о дате покупки в БД
            //    customer.Date = DateTime.Now;
            //    db.Customers.Add(customer);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(customer);
            #endregion
            SelectList waters = new SelectList(_waterContext.Waters, "Id", "WaterName");
            ViewBag.Waters = waters;
            if (ModelState.IsValid)
            {
                // добавляем информацию о дате покупки в БД
                customer.Date = DateTime.Now;
                await _customerService.AddCustomerAsync(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        [HttpGet]
        public ActionResult EditOrder(int? id) // Вопрос: как сделать это через асинхронный метод и используя сервис? 
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Customer someCustomer = _waterContext.Customers.Find(id);
            if (someCustomer != null)
            {
                SelectList waters = new SelectList(_waterContext.Waters, "Id", "WaterName");
                ViewBag.Waters = waters;
                return View(someCustomer);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> EditOrder(Customer customer)
        {
            SelectList waters = new SelectList(_waterContext.Waters, "Id", "WaterName");
            ViewBag.Waters = waters;
            if (ModelState.IsValid)
            {
                // добавляем информацию о дате покупки в БД
                customer.Date = DateTime.Now;
                await _customerService.UpdateCustomerAsync(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        public ActionResult Details(int id) // Вопрос: как сделать асинхронно и через сервис _customerService. Ответ: public ActionResult Details(int id) => public async Task<ActionResult> Details(int id), сервис думаю ты понял, сам поменяешь
        {
            Customer someCustomers = _waterContext.Customers.Find(id);
            return View(someCustomers);
        }
        public async Task<ActionResult> DeleteOrder(int id)
        {
            Customer someCustomer = _waterContext.Customers.Find(id);
            if (someCustomer != null)
            {
                await _customerService.DeleteCustomerAsync(id);
            }
            return RedirectToAction("Index");
        }
        //public ActionResult SaveNewOrder(Сustomer customer, string redirectUrl)
        //{
        //    if (!ModelState.IsValid) 
        //    {
        //        return View(customer);
        //    }

        //}
        //public ActionResult ShowOrders()
        //{
        //    var orders = db.Customers.Include(c=>c.Water).ToList();
        //    return View(orders);
        //}
        //public ActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    return RedirectToAction("Index", "Home");
        //}
    }
}