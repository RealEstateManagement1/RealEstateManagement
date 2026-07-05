using Domain.Entities;

namespace Domain.Entities
{
    public class Survey
    {
        public int Id { get; set; }
        public string PropertyId { get; set; }
        //  public Property Property { get; set; }
        public string SurveyorName { get; set; }
        public DateTime SurveyDate { get; set;}
        public string Coordinates { get; set;}

    }
}