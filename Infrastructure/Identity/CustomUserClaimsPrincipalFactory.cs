using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Infrastructure.Data;

namespace Infrastructure.Identity
{
    /// <summary>
    /// Custom claims principal factory that adds FirstName and LastName as claims.
    /// This makes user data available without additional database calls.
    /// </summary>
    public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomUserClaimsPrincipalFactory(
            UserManager<User> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IOptions<IdentityOptions> options,
            ApplicationDbContext dbContext)
            : base(userManager, roleManager, options)
        {
            _dbContext = dbContext;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            // Add custom claims for FirstName and LastName
            identity.AddClaim(new Claim("FirstName", user.FirstName ?? string.Empty));
            identity.AddClaim(new Claim("LastName", user.LastName ?? string.Empty));

            // Fetch the person and their role
            var person = await _dbContext.Persons.FindAsync(user.PersonId);
            if (person != null && !string.IsNullOrEmpty(person.Role))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, person.Role));
            }

            return identity;
        }
    }
}