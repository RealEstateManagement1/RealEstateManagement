namespace Application.DTO
{
    public class CreateOwnershipRecordDTO
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int PropertyId { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class UpdateOwnershipRecordDTO
    {
        public int OwnerId { get; set; }
        public int PropertyId { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}