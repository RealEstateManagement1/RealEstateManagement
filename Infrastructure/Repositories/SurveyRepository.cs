using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories 
{
    public class SurveyRepository : ISurvey
    {
      private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

      public SurveyRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
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

        public async Task<List<Survey>> GetAllSurveysAsync()
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            return await dbContext.Surveys
                .ToListAsync();
        }

        public async Task<Survey> GetSurveyByIdAsync(int id)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            return await dbContext.Surveys
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task CreateSurveyAsync(SurveyCreateDTO SurveyDTO)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            Survey Survey = new()
            {
                PropertyId = SurveyDTO.PropertyId,
                SurveyorName = SurveyDTO.SurveyorName,
                SurveyDate = SurveyDTO.SurveyDate,
                Coordinates = SurveyDTO.Coordinates
            };
            dbContext.Surveys.Add(Survey);
            await dbContext.SaveChangesAsync();
        }
    

    
    }
    
}
