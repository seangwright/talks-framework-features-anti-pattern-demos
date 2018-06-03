using ASPNETCoreMVC.FrameworkFocus.Web.Entities;
using ASPNETCoreMVC.FrameworkFocus.Web.Repositories.Interfaces;
using ASPNETCoreMVC.FrameworkFocus.Web.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ASPNETCoreMVC.FrameworkFocus.Web.Controllers
{
    [Authorize(Policy = "AdminRequired")]
    public class CustomersAdminController : Controller
    {
        private readonly ICustomerRepository repository;

        public CustomersAdminController(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        // GET: CustomersAdmin
        public IActionResult Index() => View(repository.FindCustomers(new CustomerSearchRequest()));

        // GET: CustomersAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await repository.GetCustomer(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: CustomersAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomersAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,IsDisabled,IsSpecial")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await repository.CreateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CustomersAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await repository.GetCustomer(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: CustomersAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,IsDisabled,IsSpecial")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdateCustomer(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CustomersAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await repository.GetCustomer(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: CustomersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await repository.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CustomerExists(int id)
        {
            return (await repository.GetCustomer(id)) != null;
        }
    }
}
