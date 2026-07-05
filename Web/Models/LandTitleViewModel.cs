using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Web.Models
{
    public class LandTitleViewModel
    {
        // Auto-generated but editable
        public string PropertyIdText { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Title number is required.")]
        public string TitleNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Issue date is required.")]
        public DateOnly IssueDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        [Required(ErrorMessage = "Expiry date is required.")]
        public DateOnly ExpiryDate { get; set; } = DateOnly.FromDateTime(DateTime.Today.AddYears(1));

        public LandTitleStatus Status { get; set; } = LandTitleStatus.Active;

        public LandTitle ToEntity()
        {
            Guid.TryParse(PropertyIdText, out var propertyId);

            return new LandTitle
            {
                Id = Guid.NewGuid(),
                PropertyId = propertyId == Guid.Empty ? Guid.NewGuid() : propertyId,
                TitleNumber = TitleNumber,
                IssueDate = IssueDate,
                ExpiryDate = ExpiryDate,
                Status = Status
            };
        }
    }
}
