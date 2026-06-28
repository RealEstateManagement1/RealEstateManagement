using Web.Components;
using MudBlazor.Services;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.FileProviders;
using Infrastructure.Data;
using Infrastructure.DependencyInjection;
using Domain.Entities;
using Application.Services.Disputes;
using Application.Interfaces;
using Application.Services.Surveys;
using Application.Services.PropertyTransfers;



var builder = WebApplication.CreateBuilder(args);

// --- 1. SERVICES REGISTRATION ---

// Database Configuration
var connectionString = builder.Configuration.GetConnectionString("LoanPlatformDBCONN")
    ?? throw new InvalidOperationException("Connection string 'LoanPlatformDBCONN' is not configured.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Infrastructure")));

builder.Services.AddScoped(p => 
    p.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());

// Identity Configuration (ONLY ONE REGISTRATION)
// Note: Ensure your 'User' class in Infrastructure matches IdentityRole<int> if that's your preference
// builder.Services.AddIdentity<User, IdentityRole<int>>(options => {
//     options.Password.RequireDigit = true;
//     options.Password.RequiredLength = 8;
// })
// .AddEntityFrameworkStores<ApplicationDbContext>()
// .AddDefaultTokenProviders();

// Core Services
// builder.Services.AddScoped<UserContext>();
builder.Services.AddMudServices();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddControllers(); // Moved up from the bottom
builder.Services.AddAuthorization(); // Moved up from the bottom

// Business Services
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddScoped<IDisputeService, DisputeService>();
builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddScoped<IPropertyTransferService, PropertyTransferService>();

// File/Location Services
// builder.Services.AddSingleton<IFileProvider>(builder.Environment.WebRootFileProvider);
// builder.Services.AddSingleton<ILocationService, JsonLocationService>();

// --- 2. BUILD THE APP ---
var app = builder.Build();

// --- 3. MIDDLEWARE PIPELINE ---

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.UseAuthentication(); // Must be before Authorization
app.UseAuthorization();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.MapControllers();

app.Run();