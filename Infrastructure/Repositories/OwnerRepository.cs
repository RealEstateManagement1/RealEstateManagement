using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


namespace Infrastructure.Repositories
{
    public class OwnerRepository : IOwner
    {
        private readonly ApplicationDbContext _dbContext;

        public OwnerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Owner>> GetAllOwnersAsync()
        {
            return await _dbContext.Owners.ToListAsync();
        }

        public async Task<Owner> GetOwnerById(int Id)
        {
            return await _dbContext.Owners.FindAsync(Id) ?? new Owner();
        }

        public async Task CreateOwner(CreateOwnerDTO ownerDTO)
        {
            if (string.IsNullOrEmpty(ownerDTO.IdentificationNumber))
            {
                throw new ArgumentException("IdentificationNumber is required.");
            }

            if (!Regex.IsMatch(ownerDTO.IdentificationNumber, @"^\d+$"))
            {
                throw new ArgumentException("IdentificationNumber must contain only digits.");
            }

            if (ownerDTO.IdentificationNumber.Length > 16)
            {
                throw new ArgumentException("IdentificationNumber must not be more than 16 digits.");
            }

            var owner = new Owner
            {
                FirstName = ownerDTO.FirstName,
                LastName = ownerDTO.LastName,
                sex = ownerDTO.sex,
                Maritalstatus = ownerDTO.Maritalstatus,
                DateOfBirth = DateTime.Now,
                IdentificationNumber = ownerDTO.IdentificationNumber,
                Email = ownerDTO.Email,
                PhoneNumber = ownerDTO.PhoneNumber,
                SpouceIdNumber = ownerDTO.SpouceIdNumber,
                NextOfKin = ownerDTO.NextOfKin,
                KinPhoneNumber = ownerDTO.KinPhoneNumber,
                SpouceName = ownerDTO.SpouceName,
                Province = ownerDTO.Province,
                District = ownerDTO.District,
                Sector = ownerDTO.Sector,
                Cell = ownerDTO.Cell,
                Village = ownerDTO.Village,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin"
            };

            _dbContext.Owners.Add(owner);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateOwner(int Id, UpdateOwnerDTO ownerDTO)
        {
            var owner = await _dbContext.Owners.FindAsync(Id);

            if (owner != null)
            {
                owner.FirstName = ownerDTO.FirstName;
                owner.LastName = ownerDTO.LastName;
                owner.sex = ownerDTO.sex;
                owner.DateOfBirth = ownerDTO.DateOfBirth;
                owner.Maritalstatus = ownerDTO.Maritalstatus;
                owner.SpouceIdNumber = ownerDTO.SpouceIdNumber;
                owner.SpouceName = ownerDTO.SpouceName;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
