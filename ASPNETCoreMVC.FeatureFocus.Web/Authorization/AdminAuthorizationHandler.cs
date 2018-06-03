using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreMVC.FeatureFocus.Web.Authorization
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
