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
