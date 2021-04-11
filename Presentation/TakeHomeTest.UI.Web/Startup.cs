using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TakeHomeTest.UI.Web.Controllers.API;
using TakeHomeTest.UI.Web.Shared;

namespace TakeHomeTest.UI.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddHttpContextAccessor();

            //var baseUrlConfig = new BaseUrlConfiguration();
            //Configuration.Bind(BaseUrlConfiguration.CONFIG_NAME, baseUrlConfig);
            //services.AddScoped<BaseUrlConfiguration>(sp => baseUrlConfig);
            //// Blazor Admin Required Services for Prerendering
            //services.AddScoped<HttpClient>(s => new HttpClient
            //{
            //    BaseAddress = new Uri(baseUrlConfig.ApiBase)
            //});

            //services.AddScoped<ProcessBase,ClockProcess > ();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Main}/{action=Home}/{id?}");
            });
        }
    }
}
