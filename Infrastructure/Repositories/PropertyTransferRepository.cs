using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories 
{
    public class PropertyTransferRepository : IPropertyTransfer
    {
      private readonly ApplicationDbContext _dbContext;

      public PropertyTransferRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

      //Retrieving Disputes

    //   public async Task<List<Dispute>> GetAllDisputesAsync()
        // {
        //     await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        //     return await dbContext.Disputes
        //     .Include(i => i.AccountType)
        //     .ToListAsync();
        // }

        // public async Task<Account?> GetAccountByIdAsync(int id)
        // {
        //      using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        //      return await dbContext.Accounts
        //     .Include(i => i.AccountType)
        //     .FirstOrDefaultAsync(i => i.Id == id);
        // }

        public async Task<List<PropertyTransfer>> GetAllPropertyTransfersAsync()
        {
            return await _dbContext.PropertyTransfers
                .ToListAsync();
        }

        public async Task<PropertyTransfer> GetPropertyTransferByIdAsync(int id)
        {
            return await _dbContext.PropertyTransfers
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task CreatePropertyTransferAsync(PropertyTransferCreateDTO PropertyTransferDTO)
        {
            PropertyTransfer PropertyTransfer = new()
            {
                PropertyId = PropertyTransferDTO.PropertyId,
                SellerId = PropertyTransferDTO.SellerId,
                BuyerId = PropertyTransferDTO.BuyerId,
                TransferType = PropertyTransferDTO.TransferType,
                TransferDate = PropertyTransferDTO.TransferDate,
                Amount = PropertyTransferDTO.Amount
            };
            _dbContext.PropertyTransfers.Add(PropertyTransfer);
            await _dbContext.SaveChangesAsync();
        }
    
    }
    
}
