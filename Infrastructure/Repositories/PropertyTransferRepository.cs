using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories 
{
    public class PropertyTransferRepository : IPropertyTransfer
    {
      private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

      public PropertyTransferRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
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
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            return await dbContext.PropertyTransfers
                .ToListAsync();
        }

        public async Task<PropertyTransfer> GetPropertyTransferByIdAsync(int id)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            return await dbContext.PropertyTransfers
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task CreatePropertyTransferAsync(PropertyTransferCreateDTO PropertyTransferDTO)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            PropertyTransfer PropertyTransfer = new()
            {
                PropertyId = PropertyTransferDTO.PropertyId,
                SellerId = PropertyTransferDTO.SellerId,
                BuyerId = PropertyTransferDTO.BuyerId,
                TransferType = PropertyTransferDTO.TransferType,
                TransferDate = PropertyTransferDTO.TransferDate,
                Amount = PropertyTransferDTO.Amount
            };
            dbContext.PropertyTransfers.Add(PropertyTransfer);
            await dbContext.SaveChangesAsync();
        }
    
    }
    
}
