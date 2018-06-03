using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPNETCoreMVC.FeatureFocus.Web.Features.Customers
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
