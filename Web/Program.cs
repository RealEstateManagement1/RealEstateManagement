using Web.Components;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Application.Interfaces;
using Application.Services.Disputes;
using Application.Services.Surveys;
using Application.Services.PropertyTransfers;
using Application.Services.Users;
using Application.Services.Properties;
using Infrastructure.Repositories;
using MudBlazor.Services;
using Microsoft.AspNetCore.Mvc;
using Application.DTO;
using Web.Services;
using MudBlazor;

var builder = WebApplication.CreateBuilder(args);

// --- 1. SERVICES REGISTRATION ---

// Register infrastructure services (includes DbContext, authentication, and identity)
builder.Services.AddInfrastructureServices(builder.Configuration);

// Core Services
builder.Services.AddMudServices();
builder.Services.AddScoped<IDialogService, DialogService>();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddControllers(); // Moved up from the bottom
builder.Services.AddAuthorization(); // Moved up from the bottom

// Business Services
builder.Services.AddScoped<IDisputeService, DisputeService>();
builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddScoped<IPropertyTransferService, PropertyTransferService>();

// File/Location Services
// builder.Services.AddSingleton<IFileProvider>(builder.Environment.WebRootFileProvider);
// builder.Services.AddSingleton<ILocationService, JsonLocationService>();

// --- 2. BUILD THE APP ---
var app = builder.Build();

// --- 3. MIDDLEWARE PIPELINE ---.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
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

app.UseAuthentication(); // Must be before Authorization
app.UseAuthorization();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.MapControllers();

app.Run();