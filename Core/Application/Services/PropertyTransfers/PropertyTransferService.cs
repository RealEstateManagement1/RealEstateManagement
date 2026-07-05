using System.Security.Cryptography.X509Certificates;
using Application.Interfaces;
using Domain.Entities;
using Application.DTO;


namespace Application.Services.PropertyTransfers
{
    
    public class PropertyTransferService : IPropertyTransferService
    {
        private readonly IPropertyTransfer _propertyTransfer;

        //Constructor
        public PropertyTransferService(IPropertyTransfer propertyTransfer)
        {
            _propertyTransfer = propertyTransfer;
        }
        
        public async Task<List<PropertyTransfer>> GetAllPropertyTransfersAsync()
        {
            return await _propertyTransfer.GetAllPropertyTransfersAsync();
        }

        public async Task<PropertyTransfer> GetPropertyTransferByIdAsync(int id)
        {
            return await _propertyTransfer.GetPropertyTransferByIdAsync(id);
        }   

        public async Task CreatePropertyTransferAsync(PropertyTransferCreateDTO propertyTransferDTO)
        {  
            await _propertyTransfer.CreatePropertyTransferAsync(propertyTransferDTO);
        }

        
    }
}