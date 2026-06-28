using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IOwner
    {
         Task<List<Owner>> GetAllOwnersAsync();
        Task<Owner> GetOwnerById(int id);   
        Task CreateOwner(CreateOwnerDTO ownerDTO);
        Task UpdateOwner(int id, UpdateOwnerDTO ownerDTO);
    }
}