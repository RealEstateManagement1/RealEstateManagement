using Domain.Entities;
using Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProperty
    {
        Task<Property> GetPropertyByIdAsync(int id);
        Task<List<Property>> GetAllPropertiesAsync();
        Task<Property> CreatePropertyAsync(PropertyCreateDTO dto);
        Task UpdatePropertyAsync(int id, PropertyUpdateDTO dto);
        Task DeletePropertyAsync(int id);
    }
}
