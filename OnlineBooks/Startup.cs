using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineBooks.Models;

namespace OnlineBooks
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //ADD A SET;
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //sets up a connection strinng the configuration holds on to the information for you?
            services.AddDbContext<OnlineBooksDbContext>(options =>
           {

               options.UseSqlite(Configuration["ConnectionStrings:BooksConnection"]);
               //options.UseSqlServer(Configuration["ConnectionStrings:BooksConnection"]); 

           });

            //services.AddDbContext<OnlineBooksDbContext>(options =>
            //options.UseSqlite(Configuration.GetConnectionString("BooksConnection")));


            //This allows the sessions to work on a miny personalized database
            services.AddScoped<IBookRespository, EFBookRespository>();
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

            //Works like an if else statement
            //What do we want the URLs to look like, and where will we send them when
            //They type something like this in
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("categorypage",
                  "{category}/{page:int}",
                  new { Controller = "Home", action = "Index" }
                  );

                endpoints.MapControllerRoute("page",
                 "Books/{page:int}",
                 new { Controller = "Home", action = "Index" }
                 );

                endpoints.MapControllerRoute("category",
                  "{category}",
                  new { Controller = "Home", action = "Index", page = 1 }
                  );

                endpoints.MapControllerRoute(
                    // This is where I change the url to be /P#
                   "pagination",
                   "/P{page}",
                   new { Controller = "Home", action = "Index" }) ;

                //Takes you to the default Index if nothing is typed into the URL
                endpoints.MapDefaultControllerRoute();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
