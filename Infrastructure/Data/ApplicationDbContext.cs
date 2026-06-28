using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Identity;

using System.Linq;
using Application.Interfaces;

namespace Infrastructure.Data
{
   public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<Property> Properties { get; set; }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            // customize Identity tables
                Builder.Entity<User>().ToTable("AspNetUsers");
                Builder.Entity<Person>().ToTable("Persons");
                Builder.Entity<IdentityRole<int>>().ToTable("Roles");
                Builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
                Builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
                Builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
                Builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
                Builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles").HasKey(ur => new { ur.UserId, ur.RoleId });
              
               
                
}
    }
}
