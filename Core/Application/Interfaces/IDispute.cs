using Application.DTO;
using Application.Interfaces;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IDispute
    {
        Task<List<Dispute>> GetAllDisputesAsync();
        Task<Dispute?> GetDisputeByIdAsync(int id);
        Task CreateDisputeAsync(DisputeCreateDTO disputeCreateDTO);
    }
}