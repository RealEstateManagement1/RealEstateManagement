$path = "C:\Users\HP\Projects\RealEstateManagement\Infrastructure\DependencyInjection\ServiceContainer.cs"

Set-Content -Path $path -Encoding utf8 -Value @"
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var conn = configuration.GetConnectionString("DefaultConnection") ?? "Data Source=app.db";
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite(conn));

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<DocumentService>();

            services.AddScoped<ILandTitleRepository, LandTitleRepository>();
            services.AddScoped<LandTitleService>();

            return services;
        }
    }
}
"@

Write-Host "ServiceContainer.cs updated successfully."