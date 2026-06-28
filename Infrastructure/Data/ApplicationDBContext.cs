using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Infrastructure.Identity;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<OwnershipRecord> OwnershipRecords { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Property> Properties { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Owner>()
                .HasOne(b => b.Person)
                .WithMany()
                .HasForeignKey(b => b.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

        }



    }


}