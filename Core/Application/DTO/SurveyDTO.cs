namespace Application.DTO
{
    public class SurveyCreateDTO
    {
       
        public int Id { get; set; }
        public string PropertyId { get; set; }
        public string SurveyorName { get; set; }
        public DateTime SurveyDate { get; set;}
        public string Coordinates { get; set;}

    }

    

    
}