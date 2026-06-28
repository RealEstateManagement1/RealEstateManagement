using Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyDetailDTO> GetPropertyByIdAsync(int id);
        Task<List<PropertyDetailDTO>> GetAllPropertiesAsync();
        Task<PropertyDetailDTO> CreatePropertyAsync(PropertyCreateDTO dto);
        Task UpdatePropertyAsync(int id, PropertyUpdateDTO dto);
        Task DeletePropertyAsync(int id);
    }
}
