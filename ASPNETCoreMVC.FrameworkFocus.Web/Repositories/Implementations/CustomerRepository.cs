using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCoreMVC.FrameworkFocus.Web.Database.Interfaces;
using ASPNETCoreMVC.FrameworkFocus.Web.Entities;
using ASPNETCoreMVC.FrameworkFocus.Web.Repositories.Interfaces;
using ASPNETCoreMVC.FrameworkFocus.Web.Requests;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreMVC.FrameworkFocus.Web.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerContext customerContext;

        public CustomerRepository(ICustomerContext customerContext) => this.customerContext = customerContext;

        public Task<int> CreateCustomer(Customer customer)
        {
            customerContext.Customers.Add(customer);
            return customerContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCustomer(int customerId)
        {
            var customer = await customerContext.Customers.FindAsync(customerId);

            customerContext.Customers.Remove(customer);

            return await customerContext.SaveChangesAsync();
        }

        public IEnumerable<Customer> FindCustomers(CustomerSearchRequest customerSearch)
        {
            IQueryable<Customer> query = customerContext.Customers;

            if (!string.IsNullOrWhiteSpace(customerSearch.Email))
            {
                query = query.Where(c => c.Email.Contains(customerSearch.Email));
            }

            if (!string.IsNullOrWhiteSpace(customerSearch.Name))
            {
                query = query.Where(c => c.Name.Contains(customerSearch.Name));
            }

            if (customerSearch.IsDisabled.HasValue)
            {
                query = query.Where(c => c.IsDisabled == customerSearch.IsDisabled.Value);
            }

            if (customerSearch.IsSpecial.HasValue)
            {
                query = query.Where(c => c.IsSpecial == customerSearch.IsSpecial.Value);
            }

            return query.AsEnumerable();
        }

        public Task<Customer> GetCustomer(int customerId) => customerContext.Customers.FindAsync(customerId);

        public Task<Customer> GetCustomer(string customerEmail) => customerContext.Customers.FirstOrDefaultAsync(c => string.Equals(c.Email, customerEmail, StringComparison.InvariantCultureIgnoreCase));

        public Task<int> UpdateCustomer(Customer customer)
        {
            customerContext.Customers.Update(customer);

            return customerContext.SaveChangesAsync();
        }
    }
}
