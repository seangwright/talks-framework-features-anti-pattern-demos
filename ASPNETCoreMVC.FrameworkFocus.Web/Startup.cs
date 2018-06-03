using ASPNETCoreMVC.FrameworkFocus.Web.AuthorizationHandlers;
using ASPNETCoreMVC.FrameworkFocus.Web.Contexts.Implementations;
using ASPNETCoreMVC.FrameworkFocus.Web.Contexts.Interfaces;
using ASPNETCoreMVC.FrameworkFocus.Web.Database.Implementations;
using ASPNETCoreMVC.FrameworkFocus.Web.Database.Interfaces;
using ASPNETCoreMVC.FrameworkFocus.Web.Repositories.Implementations;
using ASPNETCoreMVC.FrameworkFocus.Web.Repositories.Interfaces;
using ASPNETCoreMVC.FrameworkFocus.Web.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ASPNETCoreMVC.FrameworkFocus.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<CustomerContext>(options =>
            {
                options.UseInMemoryDatabase("TestDatabase");
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRequired", policy =>
                    policy.Requirements.Add(new AdminRoleRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, AdminAuthorizationHandler>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerContext, CustomerContext>();
            services.AddScoped<IEcommerceContext, EcommerceContext>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
