using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Infrastructure.Data;
using Application.Interfaces;
using Infrastructure.Repositories;

using Domain.Entities;
using Infrastructure.Identity;


namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // add infrastructure services here, e.g., DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped
                );
                // Register the UserContext as a scoped service
                services.AddScoped<IUserContext, UserContext>();
                services.AddHttpContextAccessor();
 
                // Register repositories
                services.AddScoped<IPerson, PersonRepository>();
                services.AddScoped<IProperty, PropertyRepository>();
                services.AddScoped<IDispute, DisputeRepository>();
                services.AddScoped<ISurvey, SurveyRepository>();
                services.AddScoped<IPropertyTransfer, PropertyTransferRepository>();
                services.AddScoped<IPropertyService, Application.Services.Properties.PropertyService>();

                  

                 //Regester identity service
                 services.AddAuthenticationService(configuration);
               

            // Register other infrastructure services here

            return services;
        }
    }
}
