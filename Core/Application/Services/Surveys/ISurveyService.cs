using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISurveyService
    {
        Task<List<Survey>> GetAllSurveysAsync();
        Task<Survey> GetSurveyByIdAsync(int id);
        Task CreateSurveyAsync(SurveyCreateDTO surveyCreateDTO);
        // Task UpdateAccountAsync(int id, AccountUpdateDTO accountUpdateDTO);
    }
}
