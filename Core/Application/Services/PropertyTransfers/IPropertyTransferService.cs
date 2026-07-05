using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPropertyTransferService
    {
        Task<List<PropertyTransfer>> GetAllPropertyTransfersAsync();
        Task<PropertyTransfer> GetPropertyTransferByIdAsync(int id);
        Task CreatePropertyTransferAsync(PropertyTransferCreateDTO propertyTransferCreateDTO);
        // Task UpdateAccountAsync(int id, AccountUpdateDTO accountUpdateDTO);
    }
}
