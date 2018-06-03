using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreMVC.FrameworkFocus.Web.Requests
{
    public class CustomerSearchRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public bool? IsDisabled { get; set; }
        public bool? IsSpecial { get; set; }
    }
}
