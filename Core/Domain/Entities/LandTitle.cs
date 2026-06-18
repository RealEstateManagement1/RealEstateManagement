using System;

namespace Domain.Entities
{
    public class LandTitle
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public string TitleNumber { get; set; } = string.Empty;
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public LandTitleStatus Status { get; set; }
    }

    public enum LandTitleStatus
    {
        Active,
        Expired,
        Pending,
        Suspended
    }
}