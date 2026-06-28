namespace Domain.Entities
{
    public class OwnershipRecord
    {   
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    
}