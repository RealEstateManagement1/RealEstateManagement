using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Application.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PropertyRepository : IProperty
    {
        private readonly ApplicationDbContext _dbContext;

        public PropertyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _dbContext.Properties.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Property>> GetAllPropertiesAsync()
        {
            return await _dbContext.Properties.ToListAsync();
        }

        public async Task<Property> CreatePropertyAsync(PropertyCreateDTO dto)
        {
            var property = new Property
            {
                ParcelNumber = dto.ParcelNumber,
                LandSize = dto.LandSize,
                LandUseType = dto.LandUseType,
                PropertyStatus = dto.PropertyStatus,
                PropertyLocation = dto.PropertyLocation,
                PropertyDocuments = dto.PropertyDocuments,
                PropertyEstimatedValue = dto.PropertyEstimatedValue,
                PropertyDocumentType = dto.PropertyDocumentType,
                PropertyImages = dto.PropertyImages,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.CreatedBy,
                // if PropertyDocuments can be null in UI, ensure we fail fast with a clear message
                // (DB column is NOT NULL)
                // NOTE: DTO PropertyDocuments is non-nullable, but if your caller passes null it will end up here.
                // You should validate at the API/UI layer.
                
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _dbContext.Properties.Add(property);
            await _dbContext.SaveChangesAsync();
            
            return property;
        }

        public async Task UpdatePropertyAsync(int id, PropertyUpdateDTO dto)
        {
            var property = await _dbContext.Properties.FindAsync(id);
            if (property != null)
            {
                property.ParcelNumber = dto.ParcelNumber;
                property.LandSize = dto.LandSize;
                property.LandUseType = dto.LandUseType;
                property.PropertyStatus = dto.PropertyStatus;
                property.PropertyLocation = dto.PropertyLocation;
                property.PropertyDocuments = dto.PropertyDocuments;

                property.PropertyEstimatedValue = dto.PropertyEstimatedValue;
                property.PropertyDocumentType = dto.PropertyDocumentType;
                property.PropertyImages = dto.PropertyImages;
                property.UpdatedBy = dto.UpdatedBy;
                property.UpdatedAt = DateTime.UtcNow;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeletePropertyAsync(int id)
        {
            var property = await _dbContext.Properties.FindAsync(id);
            if (property != null)
            {
                _dbContext.Properties.Remove(property);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
