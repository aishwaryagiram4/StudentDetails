using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentDetails.Models;
using System;
using System.Reflection;

namespace StudentDetails
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
            var connection = Configuration.GetConnectionString("StudentDB");
            services.AddDbContext<Models.StudentDBContext>(options => options.UseSqlServer(connection));
            
            //MVC layer Dependency Injection
            services.AddControllersWithViews();
          
            //Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            //Mapper
           var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Mapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IStudentsDataAccess,StudentsDataAccess2>();

            //Session
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            /*
              When you set a cookie with the HttpOnly flag, it informs the browser that
              this special cookie should only be accessed by the server*/
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
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            /*The endpoint route resolution is the concept of looking at the
             * incoming request and mapping the request to an endpoint using 
             * route mappings*/

        }
    }
}
