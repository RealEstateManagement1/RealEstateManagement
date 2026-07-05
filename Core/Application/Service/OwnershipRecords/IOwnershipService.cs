using Domain.Entities;
using Application.DTO;

namespace Application.Services.OwnershipRecords
{
    public interface IOwnershipRecordService
    {
        Task <OwnershipRecord> GetOwnershipRecordById(int Id);
        Task <List<OwnershipRecord>> GetAllOwnershipRecordsAsync();
        Task CreateOwnershipRecord(CreateOwnershipRecordDTO ownershipRecordDTO);
        Task UpdateOwnershipRecord(int Id, UpdateOwnershipRecordDTO ownershipRecordDTO);
    }
}