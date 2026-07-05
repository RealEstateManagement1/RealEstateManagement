using System.Security.Cryptography.X509Certificates;
using Application.Interfaces;
using Domain.Entities;
using Application.DTO;


namespace Application.Services.Disputes
{
    
    public class DisputeService : IDisputeService
    {
        private readonly IDispute _dispute;

        //Constructor
        public DisputeService(IDispute dispute)
        {
            _dispute = dispute;
        }
        
        public async Task<List<Dispute>> GetAllDisputesAsync()
        {
            return await _dispute.GetAllDisputesAsync();
        }

        public async Task<Dispute?> GetDisputeByIdAsync(int id)
        {
            return await _dispute.GetDisputeByIdAsync(id);
        }   

        public async Task CreateDisputeAsync(DisputeCreateDTO disputeDTO)
        {  
            await _dispute.CreateDisputeAsync(disputeDTO);
        }

        
    }
}