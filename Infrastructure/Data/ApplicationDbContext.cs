using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<LandTitle> LandTitles { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LandTitle>(eb =>
            {
                eb.HasKey(x => x.Id);
                eb.Property(x => x.TitleNumber).IsRequired();
            });

            modelBuilder.Entity<Document>(eb =>
            {
                eb.HasKey(x => x.Id);
                eb.Property(x => x.FileName).IsRequired();
                eb.HasOne(d => d.LandTitle)
                    .WithMany()
                    .HasForeignKey(d => d.LandTitleId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
