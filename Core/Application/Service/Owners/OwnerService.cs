using Application.Interfaces;
using Domain.Entities;
using Application.DTO;

namespace Application.Services.Owners
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwner _owner;
        public OwnerService(IOwner owner)
        {
            _owner = owner;
        }
         public async Task<List<Owner>> GetAllOwnersAsync()
        {
         return await _owner.GetAllOwnersAsync();
        }
         public async Task<Owner> GetOwnerById(int Id)
        {
            return await _owner.GetOwnerById(Id);
        }
       public async Task CreateOwner(CreateOwnerDTO ownerDTO)
        {
            await _owner.CreateOwner(ownerDTO);
        }
        public async Task UpdateOwner(int Id, UpdateOwnerDTO ownerDTO)
        {
            await _owner.UpdateOwner(Id, ownerDTO);
        }
    }
}