using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using MyFlatWEB.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFlatWEB.Models;
using MyFlatWEB.HelpMethods;
using MyFlatWEB.Data.Repositories.Abstract;
using MyFlatWEB.Data.Repositories.API;
using MyFlatWEB.Models.Account;
using MyFlatWEB.Models.Rendering;
using MyFlatWEB.Areas.Management.Models.Rendering;
using MyFlatWEB.Areas.Management.Models;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using MyFlatWEB.Areas.Management.Models.EditPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;

namespace MyFlatWEB
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<IAccountRepository, APIAccountRepository>();
            services.AddTransient<IRenderingRepository, APIRenderingRepository>();
            services.AddTransient<IPageEditorRepository, APIPageEditorRepository>();
            services.AddTransient<DataManager>();
            services.AddTransient<ErrorModel>();
            services.AddTransient<UserRolesModel>();
            services.AddTransient<UserRoles>();
            services.AddTransient<ServicesModel>();
            services.AddTransient<OrdersModel>();
            services.AddTransient<ChangeStatusModel>();
            services.AddTransient<RandomString>();
            services.AddTransient<InputDataModel>();
            services.AddTransient<PeriodModel>();
            services.AddTransient<OrdersByServiceModel>();
            services.AddTransient<HomePagePlaceholderModel>();
            services.AddTransient<RandomPhraseModel>();
            services.AddTransient<TopMenuLinkNameModel>();
            services.AddTransient<PhraseModel>();
            services.AddTransient<ProjectModel>();

            services.AddMvc();

            services.AddRouting();
            services.AddRazorPages().AddRazorRuntimeCompilation();


            //services.AddRouting(options =>
            //{
            //    options.ConstraintMap.Add("HomePagePlaceholderModel", typeof(HomePagePlaceholderModel));
            //});
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Management",
                    pattern: "{area:exists}/{controller=ManageView}/{action=ManageHome}/{id?}/{param?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{param?}");
                endpoints.MapRazorPages();
            });
        }

        //internal class ProvaRouteConstraint : IRouteConstraint
        //{
        //    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
        //                      RouteValueDictionary values, RouteDirection routeDirection)
        //    {
        //        return false;
        //    }
        //}
    }
}
