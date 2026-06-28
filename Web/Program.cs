using Web.Components;
using MudBlazor;
using Infrastructure.DependencyInjection;
using Infrastructure.Data;
using MudBlazor.Services;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Services;
using Application.Interfaces;
using Microsoft.Extensions.FileProviders;


var builder = WebApplication.CreateBuilder(args);

// --- 1. SERVICES REGISTRATION ---

// Register infrastructure services (includes DbContext)
builder.Services.AddInfrastructureServices(builder.Configuration);

// Identity configuration
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Core Services
builder.Services.AddMudServices();
builder.Services.AddScoped<IDialogService, DialogService>();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddControllers(); // Moved up from the bottom
builder.Services.AddAuthorization(); // Moved up from the bottom

// Business Services
// (IOwnerService is registered by AddInfrastructureServices)
// File/Location Services
builder.Services.AddSingleton<IFileProvider>(builder.Environment.WebRootFileProvider);
builder.Services.AddSingleton<ILocationService, JsonLocationService>();

// --- 2. BUILD THE APP ---
var app = builder.Build();

// --- 3. MIDDLEWARE PIPELINE ---.
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