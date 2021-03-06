using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

            //sets up a connection string the configuration holds on to the information for you?
            services.AddDbContext<OnlineBooksDbContext>(options =>
           {

               options.UseSqlite(Configuration["ConnectionStrings:BooksConnection"]);
               //old code used with SQL Server
               //options.UseSqlServer(Configuration["ConnectionStrings:BooksConnection"]); 

           });

            //old used code
            //services.AddDbContext<OnlineBooksDbContext>(options =>
            //options.UseSqlite(Configuration.GetConnectionString("BooksConnection")));


            //This allows the sessions to work on a miny personalized database
            services.AddScoped<IBookRespository, EFBookRespository>();

            //This allows the Model to use Razor pages
            services.AddRazorPages();

            //Stores stuff in the memory?
            services.AddDistributedMemoryCache();

            //Allow for browser sessons
            services.AddSession();

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //What type of error page to display
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

            //Set up a session for us/user
            app.UseSession();

            app.UseRouting();

            //Allow default file mapping to files (such as index.html) without specifying a directory
            //app.UseDefaultFiles();

            app.UseAuthorization();

            //Works like an if else statement
            //What do we want the URLs to look like, and where will we send them when
            //They type something like this in
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("categorypage" , //the name 
                  "{category}/{pageNum:int}", //pattern of the url
                  new { Controller = "Home", action = "Index" } //new controller object?
                  );

                //The main page with whatever page you want
                endpoints.MapControllerRoute("page",
                 "Books/{pageNum:int}",
                 new { Controller = "Home", action = "Index" }
                 );

                //This takes them to a category if it is specified in the URL - It defaults to the first page
                endpoints.MapControllerRoute("category",
                  "{category}",
                  new { Controller = "Home", action = "Index", pageNum = 1 }
                  );

                endpoints.MapControllerRoute(
                    // This is where I change the url to be /P#
                   "pagination",
                   "/P{pageNum}",
                   new { Controller = "Home", action = "Index" }) ;

                //Takes you to the default Index if nothing is typed into the URL
                endpoints.MapDefaultControllerRoute();

                //Allows you to URL to Razor papges?
                endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
