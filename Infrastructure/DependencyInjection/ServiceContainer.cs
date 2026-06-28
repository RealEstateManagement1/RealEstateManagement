using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using System.Diagnostics;
using Infrastructure.Repositories;
using Application.Interfaces;
using Application.Services.Disputes;


namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register ApplicationDbContext (service here) with SQL Server provider
            // services.AddDbContext<ApplicationDbContext>(options =>
            //  options.UseSqlServer(configuration.GetConnectionString("LoanPlatformDBCONN")),ServiceLifetime.Scoped
            //     );
                //Register authentication services
            // services.AddAuthenticationService(configuration);

             services.AddHttpContextAccessor();
             
             services.AddScoped<IDispute, DisputeRepository>();
             services.AddScoped<ISurvey, SurveyRepository>();
             services.AddScoped<IPropertyTransfer, PropertyTransferRepository>();

           


             return services;
        }
    }
}