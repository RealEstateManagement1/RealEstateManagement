using Domain.Entities;
using Application.DTO;

namespace Application.Services.Owners
{
    public interface IOwnerService
    {
        Task <Owner> GetOwnerById(int Id);
        Task <List<Owner>> GetAllOwnersAsync();
        Task CreateOwner(CreateOwnerDTO ownerDTO);
         Task UpdateOwner(int Id, UpdateOwnerDTO ownerDTO);
    }
}