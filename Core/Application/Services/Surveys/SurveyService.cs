using System.Security.Cryptography.X509Certificates;
using Application.Interfaces;
using Domain.Entities;
using Application.DTO;


namespace Application.Services.Surveys
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurvey _survey;

        //Constructor
        public SurveyService(ISurvey survey)
        {
            _survey = survey;
        }
        
        public async Task<List<Survey>> GetAllSurveysAsync()
        {
            return await _survey.GetAllSurveysAsync();
        }

        public async Task<Survey> GetSurveyByIdAsync(int id)
        {
            return await _survey.GetSurveyByIdAsync(id);
        }   

        public async Task CreateSurveyAsync(SurveyCreateDTO surveyDTO)
        {  
            await _survey.CreateSurveyAsync(surveyDTO);
        }

        
    }
}