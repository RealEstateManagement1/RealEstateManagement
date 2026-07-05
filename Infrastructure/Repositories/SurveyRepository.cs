using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories 
{
    public class SurveyRepository : ISurvey
    {
      private readonly ApplicationDbContext _dbContext;

      public SurveyRepository(ApplicationDbContext dbContext)
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

        public async Task<List<Survey>> GetAllSurveysAsync()
        {
            return await _dbContext.Surveys
                .ToListAsync();
        }

        public async Task<Survey> GetSurveyByIdAsync(int id)
        {
            return await _dbContext.Surveys
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task CreateSurveyAsync(SurveyCreateDTO SurveyDTO)
        {
            Survey Survey = new()
            {
                PropertyId = SurveyDTO.PropertyId,
                SurveyorName = SurveyDTO.SurveyorName,
                SurveyDate = SurveyDTO.SurveyDate,
                Coordinates = SurveyDTO.Coordinates
            };
            _dbContext.Surveys.Add(Survey);
            await _dbContext.SaveChangesAsync();
        }
    

    
    }
    
}
