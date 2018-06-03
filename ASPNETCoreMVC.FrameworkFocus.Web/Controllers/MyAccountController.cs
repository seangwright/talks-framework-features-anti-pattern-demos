using ASPNETCoreMVC.FrameworkFocus.Web.Contexts.Interfaces;
using ASPNETCoreMVC.FrameworkFocus.Web.Models;
using ASPNETCoreMVC.FrameworkFocus.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASPNETCoreMVC.FrameworkFocus.Web.Controllers
{
    public class MyAccountController : Controller
    {
        private readonly IEcommerceContext ecommerceContext;
        private readonly ICustomerRepository repository;

        public MyAccountController(IEcommerceContext ecommerceContext, ICustomerRepository repository)
        {
            this.ecommerceContext = ecommerceContext;
            this.repository = repository;
        }

        // GET: MyAccount
        public async Task<IActionResult> Index()
        {
            var customer = await ecommerceContext.CurrentCustomer();

            var customerModel = new CustomerAccountViewModel
            {
                Email = customer.Email,
                Name = customer.Name
            };

            return View(customerModel);
        }

        // POST: MyAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Name,Email")] CustomerAccountViewModel customerModel)
        {
            if (ModelState.IsValid)
            {
                var customer = await ecommerceContext.CurrentCustomer();

                customer.Email = customerModel.Email;
                customer.Name = customerModel.Name;

                await repository.UpdateCustomer(customer);

                return RedirectToAction(nameof(Index));
            }

            return View(customerModel);
        }

        private async Task<bool> CustomerExists(int id)
        {
            return (await repository.GetCustomer(id)) != null;
        }
    }
}
