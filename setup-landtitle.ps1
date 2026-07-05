$base = "C:\Users\HP\Projects\RealEstateManagement"

# ILandTitleRepository.cs
Set-Content -Path "$base\Infrastructure\Repository\Interfaces\ILandTitleRepository.cs" -Encoding utf8 -Value @"
using Domain.Entities;

namespace Infrastructure.Repository.Interfaces
{
    public interface ILandTitleRepository
    {
        Task<IEnumerable<LandTitle>> GetAllAsync();
        Task<LandTitle?> GetByIdAsync(Guid id);
        Task AddAsync(LandTitle landTitle);
        Task UpdateAsync(LandTitle landTitle);
        Task DeleteAsync(Guid id);
    }
}
"@

# LandTitleRepository.cs
Set-Content -Path "$base\Infrastructure\Repository\LandTitleRepository.cs" -Encoding utf8 -Value @"
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class LandTitleRepository : ILandTitleRepository
    {
        private readonly ApplicationDbContext _context;

        public LandTitleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LandTitle>> GetAllAsync()
        {
            return await _context.LandTitles.ToListAsync();
        }

        public async Task<LandTitle?> GetByIdAsync(Guid id)
        {
            return await _context.LandTitles.FindAsync(id);
        }

        public async Task AddAsync(LandTitle landTitle)
        {
            landTitle.Id = Guid.NewGuid();
            await _context.LandTitles.AddAsync(landTitle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LandTitle landTitle)
        {
            _context.LandTitles.Update(landTitle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var title = await _context.LandTitles.FindAsync(id);
            if (title is not null)
            {
                _context.LandTitles.Remove(title);
                await _context.SaveChangesAsync();
            }
        }
    }
}
"@

# LandTitleService.cs
Set-Content -Path "$base\Infrastructure\Services\LandTitleService.cs" -Encoding utf8 -Value @"
using Domain.Entities;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Services
{
    public class LandTitleService
    {
        private readonly ILandTitleRepository _repository;

        public LandTitleService(ILandTitleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LandTitle>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<LandTitle?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(LandTitle landTitle)
        {
            await _repository.AddAsync(landTitle);
        }

        public async Task UpdateAsync(LandTitle landTitle)
        {
            await _repository.UpdateAsync(landTitle);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
"@

Write-Host "Done! Files written successfully."