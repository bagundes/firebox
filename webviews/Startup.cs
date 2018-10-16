using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webviews.Repositories.Administration;
using webviews.Repositories.Documents;
using webviews.Repositories.Invariable;
using webviews.Repositories.Partners;

namespace webviews
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
            services.AddDistributedMemoryCache();
            services.AddSession( options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "Firebox.Session";
 
            });
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/login";
                        options.LoginPath = "/logout";
                        options.Cookie.Expiration = TimeSpan.FromMinutes(60);
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    });


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddSessionStateTempDataProvider();

            services.AddSession();

            services.AddTransient<IHttpContextAccessor,HttpContextAccessor>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<ISalesOrderRepository,SalesOrderRepository>();
            services.AddTransient<ISalesOrder_ItemRepository,SalesOrder_ItemRepository>();
            services.AddTransient<ISalesOrder_TaxRepository,SalesOrder_TaxRepository>();
            services.AddTransient<IPerfilRepository, PerfilRepository>();
            services.AddTransient<ISessionRepository, SessionRepository>();
            services.AddTransient<IModuleRepository, ModuleRepository>();
            services.AddTransient<IVendorRepository, VendorRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ISalesOrderRepository, SalesOrderRepository>();
            services.AddTransient<IBusinessPartnerRepository, BusinessPartnerRepository>();

            services.AddDbContext<AppContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, AppContext Context)
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
            
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

             serviceProvider.GetService<AppContext>().Database.Migrate();serviceProvider.GetService<AppContext>().Database.Migrate();

            // Criando usuário
            var user = new Repositories.Administration.UserRepository(Context);
            user.CreateDefault();
            var module = new Repositories.Administration.ModuleRepository(Context);
            module.CreateDefault();
            var perfil = new PerfilRepository(Context);
            perfil.CreateDefault();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Access}/{action=Login}");
            });

        }
    }
}
