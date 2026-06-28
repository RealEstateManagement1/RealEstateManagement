using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDisputeService
    {
        Task<List<Dispute>> GetAllDisputesAsync();
        Task<Dispute?> GetDisputeByIdAsync(int id);
        Task CreateDisputeAsync(DisputeCreateDTO disputeCreateDTO);
        // Task UpdateAccountAsync(int id, AccountUpdateDTO accountUpdateDTO);
    }
}
