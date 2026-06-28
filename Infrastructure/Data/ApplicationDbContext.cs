using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
// using Infrastructure.Identity;
using System.Linq;

namespace Infrastructure.Data
{
    // public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dispute> Disputes { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<PropertyTransfer> PropertyTransfers { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
            // 1. MUST call base first for Identity configurations
            // base.OnModelCreating(builder);

            // 2. Fix Cascade Path for Disbursements
            // builder.Entity<Dispute>();
                // .HasOne(d => d.PaymentModality)
                // .WithMany() 
                // .HasForeignKey(d => d.PaymentModalityId)
                // .OnDelete(DeleteBehavior.Restrict);

      
    // // Disable cascade delete between Borrower and ProcessFeeDeposits
    //     builder.Entity<ProcessFeeDeposit>()
    //     .HasOne(p => p.Borrower)
    //     .WithMany() 
    //     .HasForeignKey(p => p.BorrowerId)
    //     .OnDelete(DeleteBehavior.NoAction);

    //         // 3. Set Decimal Precision globally
    //         foreach (var property in builder.Model.GetEntityTypes()
    //             .SelectMany(t => t.GetProperties())
    //             .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
    //         {
    //             property.SetColumnType("decimal(18,2)");
    //         }

    //         // 4. Enum Conversions
    //         builder.Entity<LoanApplication>()
    //             .Property(t => t.Status)
    //             .HasConversion<string>();

            // 5. Identity Table Renaming
            // builder.Entity<User>().ToTable("Users");
            // builder.Entity<IdentityRole<int>>().ToTable("Roles");
            // builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            // builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            // builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            // builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            // builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");

            // Note: base.OnModelCreating already handles the composite key for UserRoles. 
            // Re-declaring it is usually unnecessary unless you've changed the Identity behavior significantly.
        }
    }
