using Application.DTO;
using Application.Interfaces;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface ISurvey
    {
        Task<List<Survey>> GetAllSurveysAsync();
        Task<Survey> GetSurveyByIdAsync(int id);
        Task CreateSurveyAsync(SurveyCreateDTO surveyCreateDTO);
    }
}