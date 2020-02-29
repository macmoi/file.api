using System;
using AutoMapper;
using file.Core;
using file.Core.Services;
using file.Persistance;
using file.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace file.Api
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
            // Setting controllers
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            
            // Setting Database
            services.AddDbContextPool<ApiDbContext>(p => 
                p.UseMySql(Configuration.GetConnectionString("DBConnection"), op => { 
                    op.ServerVersion(new Version(5,7,29), ServerType.MySql); // Change the version depending of your MySQL Version
                    op.MigrationsAssembly("file.Persistance");
                })
            );

            // Setting dependency injection of services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAttachmentService, AttachmentService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
