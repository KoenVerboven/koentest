using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using packt_webapp.Entities;
using Microsoft.EntityFrameworkCore;
using packt_webapp.Repositories;
using packt_webapp.Dtos;
using packt_webapp.Middlewares;

namespace packt_webapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()// toegevoegd door koen
            .SetBasePath(env.ContentRootPath)// toegevoegd door koen
            .AddJsonFile("appsettings.json")// toegevoegd door koen
            .AddEnvironmentVariables();// toegevoegd door koen

            //Configuration = builder.Build();// toegevoegd door koen (nog uitvinken en onderstaande uitvinken)

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //onderstaan heeft koen toegevoegd:
            services.AddDbContext<PacktDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            //onderstaande regel ook toegevoegd door Koen:
            services.AddScoped<ISeedDataService,SeedDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //onderstaande (automapper) toegevoegd door koen : (na corretie code uitvinken)
            //AutoMapper.Mapper.Initialize(mapper =>
            //{ 
            //          mapper.CreateMap<Customer, CustomerDto>().ReverseMap()
            //});

            //onderstaande regel toegevoegd door Koen
            //vink deze regel uit om de database te vullen met data:
            //app.AddSeedData();
               
            
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
