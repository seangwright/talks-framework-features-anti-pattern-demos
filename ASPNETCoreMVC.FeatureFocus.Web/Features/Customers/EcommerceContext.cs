using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreMVC.FeatureFocus.Web.Features.Customers
{
    public class EcommerceContext : IEcommerceContext
    {
        private readonly ICustomerRepository repository;
        private readonly int? currentCustomerId;

        public EcommerceContext(ICustomerRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            this.repository = repository;

            var customerCookie = httpContextAccessor
                .HttpContext
                .Request
                .Cookies
                .FirstOrDefault(c => c.Key.Equals("CustomerId", StringComparison.InvariantCultureIgnoreCase));

            if (int.TryParse(customerCookie.Value, out int cookieCustomerId))
            {
                currentCustomerId = cookieCustomerId;
            }
        }

        public Task<Customer> CurrentCustomer() => currentCustomerId == null
            ? Task.FromResult<Customer>(null)
            : repository.GetCustomer(currentCustomerId.Value);
    }
}
