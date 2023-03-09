using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission09_sideaton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mission09_sideaton
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BooksDBConnection"]);
            });
            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Tells app to use the files in the wwwroot folder
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Name, pattern, defualts
                endpoints.MapControllerRoute("categorypage","{bookCategory}/Page{pageNum}", new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("Paging", "{pageNum}", new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapControllerRoute("category", "{bookCategory}", new { Controller = "Home", action = "Index" , pageNum = 1});

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
