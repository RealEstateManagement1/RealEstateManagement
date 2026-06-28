using Domain.Entities;

namespace Domain.Entities
{
    public class Dispute
    {
        public int Id { get; set; }
        public string? PropertyId { get; set; }
        //  public Property Property { get; set; }
        public string? Complainant { get; set; }
        public string? Description { get; set;}
        public string? Status { get; set;}

    }
}