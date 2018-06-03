using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreMVC.FeatureFocus.Web.Features.Customers
{
    public class CustomerContext : DbContext, ICustomerContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
