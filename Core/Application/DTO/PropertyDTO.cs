using System;

namespace Application.DTO
{
    public class PropertyCreateDTO
    {
        public string ParcelNumber { get; set; }
        public string LandSize { get; set; }
        public string LandUseType { get; set; }
        public string PropertyStatus { get; set; }
        public string PropertyLocation { get; set; }
        public string PropertyDocuments { get; set; }
        public decimal PropertyEstimatedValue { get; set; }
        public string PropertyDocumentType { get; set; }
        public string CreatedBy { get; set; }
        public string? PropertyImages { get; set; }
    }

    public class PropertyUpdateDTO
    {
        public string ParcelNumber { get; set; }
        public string LandSize { get; set; }
        public string LandUseType { get; set; }
        public string PropertyStatus { get; set; }
        public string PropertyLocation { get; set; }
        public string PropertyDocuments { get; set; }
        public decimal PropertyEstimatedValue { get; set; }
        public string PropertyDocumentType { get; set; }
        public string UpdatedBy { get; set; }
        public string? PropertyImages { get; set; }
    }

    public class PropertyDetailDTO
    {
        public int Id { get; set; }
        public string ParcelNumber { get; set; }
        public string LandSize { get; set; }
        public string LandUseType { get; set; }
        public string PropertyStatus { get; set; }
        public string PropertyLocation { get; set; }
        public string PropertyDocuments { get; set; }
        public decimal PropertyEstimatedValue { get; set; }
        public string PropertyDocumentType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string? PropertyImages { get; set; }
    }
}
