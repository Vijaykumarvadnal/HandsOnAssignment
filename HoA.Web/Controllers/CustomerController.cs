using System.Linq;
using HoA.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HoA.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View(_customerService.GetAll().ToList());
        }
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerService.Get(_customerService.GetAll().FirstOrDefault(x => x.ID == id));
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
    }
}