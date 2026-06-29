using Web.Components;
using MudBlazor.Services;
using Infrastructure.DependencyInjection;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Application.Interfaces;
using Application.Services.Users;
using Application.Services.Properties;
using Infrastructure.Repositories;
using MudBlazor.Services;
using Microsoft.AspNetCore.Mvc;
using Application.DTO;
using Web.Services;

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

// Add MudBlazor services
builder.Services.AddMudServices();

// Add Language Service (Singleton for app-wide use)
builder.Services.AddSingleton<LanguageService>();

// Configure Entity Framework Core
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add Identity services
builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Add authentication and authorization
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

// Register application services
builder.Services.AddScoped<IIdentity, IdentityRepository>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IProperty, PropertyRepository>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IUserContext, UserContext>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddMudServices();

// Infrastructure services: DbContext, repositories, LandTitleService, DocumentService
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Ensure the database is created and migrations are applied
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// --- 3. MIDDLEWARE PIPELINE ---.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.UseStatusCodePagesWithReExecute("/Error");
app.UseHttpsRedirection();
app.UseAntiforgery();

// Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapPost("/api/account/login", async (
    [FromForm] string email,
    [FromForm] string password,
    [FromForm] string? rememberMe,
    [FromForm] string? returnUrl,
    [FromServices] IIdentityService identityService,
    [FromServices] UserManager<User> userManager,
    [FromServices] ApplicationDbContext dbContext,
    HttpContext httpContext) =>
{
    bool isRemembered = rememberMe == "on" || rememberMe == "true";
    var success = await identityService.LoginAsync(new LoginDTO
    {
        Email = email,
        Password = password,
        RememberMe = isRemembered
    });

    if (success)
    {
        // Get the logged-in user
        var user = await userManager.FindByEmailAsync(email);
        if (user != null)
        {
            // Get the associated Person entity
            var person = await dbContext.Persons.FirstOrDefaultAsync(p => p.Id == user.PersonId);
            
            // Check if user has a role; if not, redirect to client dashboard
            if (person != null && string.IsNullOrEmpty(person.Role))
            {
                return Results.Redirect("/client-dashboard");
            }
        }
        
        return Results.Redirect(string.IsNullOrEmpty(returnUrl) ? "/dashboard" : returnUrl);
    }

    return Results.Redirect("/account/login?error=Invalid email or password");
})
.DisableAntiforgery();

app.MapGet("/api/account/logout", async (
    [FromServices] SignInManager<User> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Redirect("/account/login");
});

app.MapPost("/api/account/logout", async (
    [FromServices] SignInManager<User> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Redirect("/account/login");
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAuthentication(); // Must be before Authorization
app.UseAuthorization();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.MapControllers();

app.Run();