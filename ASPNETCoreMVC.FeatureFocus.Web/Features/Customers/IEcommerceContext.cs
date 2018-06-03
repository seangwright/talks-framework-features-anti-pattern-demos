using System.Threading.Tasks;

namespace ASPNETCoreMVC.FeatureFocus.Web.Features.Customers
{
    public interface IEcommerceContext
    {
        Task<Customer> CurrentCustomer();
    }
}
