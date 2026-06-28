namespace Domain.Entities
{
    public class Property{
        public int Id {get;set;}
        public string ParcelNumber {get;set;}
        public string LandSize {get;set;}
        public string LandUseType {get;set;}
        public string PropertyStatus {get;set;}
        public string PropertyLocation {get;set;}
        public string PropertyDocuments {get;set;}
        public decimal PropertyEstimatedValue{get;set;}
        public string PropertyDocumentType{get;set;}

        //Auditing
        
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public string CreatedBy {get;set;}
        public string UpdatedBy {get;set;}
         
        
    }
}