namespace Domain.Entities
{
   public class TaxRecords
    {
        public int Id { get; set; }
        public int  PropertyId { get; set; }
        public Property Property  { get; set; }
        public decimal TaxYear { get; set; }
        public decimal  TaxAmountdue { get; set; }
        public decimal  TaxAmountPaid { get; set; }
        // public string Status (Paid or unpaid) { get; set; }

        // Auditing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}