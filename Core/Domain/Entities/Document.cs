using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    /// <summary>
    /// Represents a file/document attached to a land title or property.
    /// Designed to be realistic for storage of metadata and binary content.
    /// </summary>
    public class Document
    {
        [Key]
        public Guid Id { get; set; }

        // Optional relation to a LandTitle (if applicable). Keep nullable to allow
        // documents not tied to a specific title.
        public Guid? LandTitleId { get; set; }

        public Guid? PropertyId { get; set; }
        
        public string DocumentType { get; set; } = string.Empty;

        // Stored filename as uploaded by user
        [Required]
        public string FileName { get; set; } = string.Empty;

        // MIME/content type (e.g. application/pdf, image/png)
        public string ContentType { get; set; } = string.Empty;

        // Binary content. In production you might store files on disk or cloud and
        // keep only a path/URL here — storing bytes in the DB is optional.
        // We'll support storing files on disk and keep the `FilePath` to the saved file.
        public byte[]? Content { get; set; }

        // File path relative to the web root (e.g. /Uploads/...). Preferred for disk storage.
        public string? FilePath { get; set; }

        // File size in bytes
        public long Size { get; set; }

        // Upload timestamp
        public DateTimeOffset UploadedAt { get; set; } = DateTimeOffset.UtcNow;

        // Optional user-supplied description
        public string Description { get; set; } = string.Empty;

        // Navigation property (virtual for EF proxies)
        public virtual LandTitle? LandTitle { get; set; }
    }
}