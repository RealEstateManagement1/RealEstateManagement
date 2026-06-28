using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(ApplicationDbContext context)
        {
            // Ensure the database is created
            await context.Database.MigrateAsync();

            // Check if data already exists
            if (await context.Owners.AnyAsync())
            {
                return; // Database has been seeded
            }

            // Seed sample owners
            var owners = new List<Owner>
            {
                new Owner
                {
                    FirstName = "Jean",
                    LastName = "Imanishimwe",
                    IdentificationNumber = "1199840234567",
                    PhoneNumber = "+250788123456",
                    Email = "jean.imanishimwe@example.com",
                    Province = "Kigali",
                    District = "Kicukiro",
                    Sector = "Kimisagara",
                    Cell = "Amahoro",
                    Village = "Ingara",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "Seed"
                },
                new Owner
                {
                    FirstName = "Marie",
                    LastName = "Mukantabana",
                    IdentificationNumber = "1198765432109",
                    PhoneNumber = "+250789234567",
                    Email = "marie.mukantabana@example.com",
                    Province = "Kigali",
                    District = "Gasabo",
                    Sector = "Ndera",
                    Cell = "Mwenge",
                    Village = "Kabeza",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "Seed"
                },
                new Owner
                {
                    FirstName = "Pierre",
                    LastName = "Uwizeyimana",
                    IdentificationNumber = "1197654321098",
                    PhoneNumber = "+250790345678",
                    Email = "pierre.uwizeyimana@example.com",
                    Province = "Southern",
                    District = "Nyaruguru",
                    Sector = "Nyaruguru",
                    Cell = "Cyigaba",
                    Village = "Kibuye",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "Seed"
                },
                new Owner
                {
                    FirstName = "Josephine",
                    LastName = "Murubu",
                    IdentificationNumber = "1196543210987",
                    PhoneNumber = "+250791456789",
                    Email = "josephine.murubu@example.com",
                    Province = "Western",
                    District = "Rusizi",
                    Sector = "Rusizi",
                    Cell = "Nyamasheke",
                    Village = "Gitaza",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "Seed"
                },
                new Owner
                {
                    FirstName = "David",
                    LastName = "Shyaka",
                    IdentificationNumber = "1195432109876",
                    PhoneNumber = "+250792567890",
                    Email = "david.shyaka@example.com",
                    Province = "Northern",
                    District = "Gakenke",
                    Sector = "Gakenke",
                    Cell = "Busenyi",
                    Village = "Muringa",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "Seed"
                }
            };

            await context.Owners.AddRangeAsync(owners);
            await context.SaveChangesAsync();
        }
    }
}
