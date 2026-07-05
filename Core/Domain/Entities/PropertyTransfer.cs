namespace Domain.Entities
{
    public class PropertyTransfer
    {
        public int Id { get; set; }
        public string? PropertyId { get; set; }
        public string? SellerId { get; set; }
        public string? BuyerId { get; set; }
        public string? TransferType { get; set; }
        public DateTime TransferDate { get; set; }
        public decimal Amount { get; set; }
    }
}