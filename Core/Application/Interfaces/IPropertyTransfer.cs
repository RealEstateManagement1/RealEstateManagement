using Application.DTO;
using Application.Interfaces;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IPropertyTransfer
    {
        Task<List<PropertyTransfer>> GetAllPropertyTransfersAsync();
        Task<PropertyTransfer> GetPropertyTransferByIdAsync(int id);
        Task CreatePropertyTransferAsync(PropertyTransferCreateDTO propertyTransferCreateDTO);
    }
}