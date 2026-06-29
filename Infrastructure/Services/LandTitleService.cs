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
