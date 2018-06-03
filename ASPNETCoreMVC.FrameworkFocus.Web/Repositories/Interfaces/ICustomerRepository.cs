using ASPNETCoreMVC.FrameworkFocus.Web.Entities;
using ASPNETCoreMVC.FrameworkFocus.Web.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPNETCoreMVC.FrameworkFocus.Web.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(int customerId);
        Task<Customer> GetCustomer(string customerEmail);
        IEnumerable<Customer> FindCustomers(CustomerSearchRequest customerSearch);
        Task<int> CreateCustomer(Customer customer);
        Task<int> UpdateCustomer(Customer customer);
        Task<int> DeleteCustomer(int customerId);
    }
}
