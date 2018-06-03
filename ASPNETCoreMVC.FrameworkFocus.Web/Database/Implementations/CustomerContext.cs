using ASPNETCoreMVC.FrameworkFocus.Web.Database.Interfaces;
using ASPNETCoreMVC.FrameworkFocus.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreMVC.FrameworkFocus.Web.Database.Implementations
{
    public class CustomerContext : DbContext, ICustomerContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
