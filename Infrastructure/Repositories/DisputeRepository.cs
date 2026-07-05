using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories 
{
    public class DisputeRepository : IDispute
    {
      private readonly ApplicationDbContext _dbContext;

      public DisputeRepository(ApplicationDbContext dbContext)
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

        public async Task<List<Dispute>> GetAllDisputesAsync()
        {
            return await _dbContext.Disputes
                .ToListAsync();
        }

        public async Task<Dispute?> GetDisputeByIdAsync(int id)
        {
            return await _dbContext.Disputes
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task CreateDisputeAsync(DisputeCreateDTO DisputeDTO)
        {
            Dispute Dispute = new()
            {
                PropertyId = DisputeDTO.PropertyId,
                Complainant = DisputeDTO.Complainant,
                Description = DisputeDTO.Description,
                Status = DisputeDTO.Status
            };
            _dbContext.Disputes.Add(Dispute);
            await _dbContext.SaveChangesAsync();
        }
    

    
    }
    
}
