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
