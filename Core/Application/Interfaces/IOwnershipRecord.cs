using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IOwnershipRecord
    {
         Task<List<OwnershipRecord>> GetAllOwnershipRecordsAsync();
        Task<OwnershipRecord> GetOwnershipRecordById(int id);   
        Task CreateOwnershipRecord(CreateOwnershipRecordDTO ownershipRecordDTO);
        Task UpdateOwnershipRecord(int id, UpdateOwnershipRecordDTO ownershipRecordDTO);
    }
}