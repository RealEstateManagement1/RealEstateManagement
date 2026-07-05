using Application.Interfaces;
using Application.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Service.Properties
{
    public class PropertyService : IPropertyService
    {
        private readonly IProperty _propertyRepository;

        public PropertyService(IProperty propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<PropertyDetailDTO> GetPropertyByIdAsync(int id)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(id);
            if (property == null) return null;

            return MapToDetailDTO(property);
        }

        public async Task<List<PropertyDetailDTO>> GetAllPropertiesAsync()
        {
            var properties = await _propertyRepository.GetAllPropertiesAsync();
            return properties.Select(MapToDetailDTO).ToList();
        }

        public async Task<PropertyDetailDTO> CreatePropertyAsync(PropertyCreateDTO dto)
        {
            var property = await _propertyRepository.CreatePropertyAsync(dto);
            return MapToDetailDTO(property);
        }

        public async Task UpdatePropertyAsync(int id, PropertyUpdateDTO dto)
        {
            await _propertyRepository.UpdatePropertyAsync(id, dto);
        }

        public async Task DeletePropertyAsync(int id)
        {
            await _propertyRepository.DeletePropertyAsync(id);
        }

        private PropertyDetailDTO MapToDetailDTO(Domain.Entities.Property property)
        {
            return new PropertyDetailDTO
            {
                Id = property.Id,
                ParcelNumber = property.ParcelNumber,
                LandSize = property.LandSize,
                LandUseType = property.LandUseType,
                PropertyStatus = property.PropertyStatus,
                PropertyLocation = property.PropertyLocation,
                PropertyDocuments = property.PropertyDocuments,
                PropertyEstimatedValue = property.PropertyEstimatedValue,
                PropertyDocumentType = property.PropertyDocumentType,
                CreatedAt = property.CreatedAt,
                UpdatedAt = property.UpdatedAt,
                CreatedBy = property.CreatedBy,
                UpdatedBy = property.UpdatedBy
            };
        }
    }
}
