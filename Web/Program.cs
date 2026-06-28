using Web.Components;
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

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
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

app.Run();
