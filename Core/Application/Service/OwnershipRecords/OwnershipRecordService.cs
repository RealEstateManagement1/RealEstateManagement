using Application.Interfaces;
using Domain.Entities;
using Application.DTO;

namespace Application.Services.OwnershipRecords
{
    public class OwnershipRecordService : IOwnershipRecordService
    {
        private readonly IOwnershipRecord _ownershipRecord;
        public OwnershipRecordService(IOwnershipRecord ownershipRecord)
        {
            _ownershipRecord = ownershipRecord;
        }
         public async Task<List<OwnershipRecord>> GetAllOwnershipRecordsAsync()
        {
         return await _ownershipRecord.GetAllOwnershipRecordsAsync();
        }
         public async Task<OwnershipRecord> GetOwnershipRecordById(int Id)
        {
            return await _ownershipRecord.GetOwnershipRecordById(Id);
        }
       public async Task CreateOwnershipRecord(CreateOwnershipRecordDTO ownershipRecordDTO)
        {
            await _ownershipRecord.CreateOwnershipRecord(ownershipRecordDTO);
        }
        public async Task UpdateOwnershipRecord(int Id, UpdateOwnershipRecordDTO ownershipRecordDTO)
        {
            await _ownershipRecord.UpdateOwnershipRecord(Id, ownershipRecordDTO);
        }
    }
}