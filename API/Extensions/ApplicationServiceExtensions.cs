using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            //addscoped sets the life cycle of service.
            //here the life cycle of this service is equal to http request
            //when request is created life cycle starts, when request is completed
            //life cycle ends
            services.AddScoped<ITokenService, TokenService>(); 
            services.AddDbContext<DataContext>(options =>
                options.UseSqlite(config.GetConnectionString("DefaultConnection"))
            );

            return services;
        }
    }
}