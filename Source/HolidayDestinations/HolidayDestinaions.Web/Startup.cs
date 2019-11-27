using AutoMapper;
using HolidayDestinations.Application.Destinations.Queries.GetDestinaton;
using HolidayDestinations.Application.Infrastructure.AutoMapper;
using HolidayDestinations.Application.Interfaces;
using HolidayDestinations.Persistance;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HolidayDestinations.Web
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
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            services.AddDbContext<IHolidayDestinationsDbContext, HolidayDestinationsDbContext>(options =>
                 options.UseMySQL("server=localhost;database=holiday_destinations_staging;user=root;password="));

            services.AddMediatR(typeof(GetDestinationQueryHandler).GetTypeInfo().Assembly);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();
        }
    }
}
