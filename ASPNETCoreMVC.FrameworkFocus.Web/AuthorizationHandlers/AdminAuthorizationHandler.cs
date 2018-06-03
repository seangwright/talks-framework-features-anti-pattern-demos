using ASPNETCoreMVC.FrameworkFocus.Web.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreMVC.FrameworkFocus.Web.AuthorizationHandlers
{
    public class AdminAuthorizationHandler : AuthorizationHandler<AdminRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRoleRequirement requirement)
        {
            if (context.Resource is AuthorizationFilterContext mvcContext)
            {
                bool isAdmin = mvcContext
                    .HttpContext
                    .Request
                    .Cookies
                    .Where(q => q.Key.Equals("isAdmin", StringComparison.InvariantCultureIgnoreCase))
                    .Any(q => q.Value.Equals("true", StringComparison.InvariantCultureIgnoreCase));

                if (isAdmin)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
