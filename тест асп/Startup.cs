using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using тест_асп.Data;
using тест_асп.Data.interfeises;
using тест_асп.Data.Mock;
using тест_асп.Data;
using тест_асп.Data.repothitory;
using тест_асп.Data.models;

namespace тест_асп 
{
    public class Startup
    {
        private IConfigurationRoot confstring;
        public Startup(IHostingEnvironment hosting) {
            confstring = new ConfigurationBuilder().SetBasePath(hosting.ContentRootPath).AddJsonFile("DBsettings1.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContent>(options => options.UseSqlServer(confstring.GetConnectionString("DefaultConnection")));
            services.AddTransient<iAllCars, CarRep>();
            services.AddTransient<iCarsCategory, CategorRep>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(we => ShopCart.getCart(we));

            services.AddMvc();
          services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            //    routes.MapRoute(name: "categoryFilter", template: "{Controller=Cars}/{action =List}/{cat?}");
            //});

            AppDbContent dbContent;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                dbContent = scope.ServiceProvider.GetRequiredService<AppDbContent>();
                DbObject.initial(dbContent);
            }

        }
    }
}
