using System.Linq;
using System.Threading.Tasks;
using HoA.Entity;
using HoA.Service.Contracts;
using HoA.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace HoA.UI.Controllers
{
    // we can change this controller to Web API by decorating with 
    //[Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(_customerService.GetAll().ToList());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(long? id)
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

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ProductId,Name,Category,Color,UnitPrice,AvailableQuantity,CratedDate")]
            Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.Insert(customer);
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(long? id)
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

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id,
            [Bind("ProductId,Name,Category,Color,UnitPrice,AvailableQuantity,CratedDate")]
            Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _customerService.Update(customer);
                }
                catch
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(long? id)
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

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var customer = _customerService.Get(_customerService.GetAll().FirstOrDefault(x => x.ID == id));
            _customerService.Delete(customer);
            return RedirectToAction(nameof(Index));
        }
    }
}