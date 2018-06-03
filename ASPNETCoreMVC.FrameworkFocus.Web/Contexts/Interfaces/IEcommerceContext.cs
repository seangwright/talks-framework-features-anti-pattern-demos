using ASPNETCoreMVC.FrameworkFocus.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreMVC.FrameworkFocus.Web.Contexts.Interfaces
{
    public interface IEcommerceContext
    {
        Task<Customer> CurrentCustomer();
    }
}
