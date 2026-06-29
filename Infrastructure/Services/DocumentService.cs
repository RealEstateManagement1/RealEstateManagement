using Domain.Entities;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DocumentService
    {
        private readonly IDocumentRepository _repository;
        private readonly IWebHostEnvironment _env;

        public DocumentService(IDocumentRepository repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        public async Task<Document> SaveAsync(IFormFile file, Guid? landTitleId, string? description, Guid? propertyId = null, string documentType = "", DateTimeOffset? uploadDate = null)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));

            using var stream = file.OpenReadStream();
            return await SaveFromStreamAsync(stream, file.FileName, file.ContentType, file.Length, landTitleId, description, propertyId, documentType, uploadDate);
        }

        public async Task<Document> SaveFromStreamAsync(Stream stream, string fileName, string contentType, long size, Guid? landTitleId, string? description, Guid? propertyId = null, string documentType = "", DateTimeOffset? uploadDate = null)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            var uploads = Path.Combine(_env.WebRootPath ?? "wwwroot", "Uploads");
            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

            var unique = $"{Guid.NewGuid():N}_{Path.GetFileName(fileName)}";
            var physicalPath = Path.Combine(uploads, unique);

            // Copy stream to disk
            using (var fs = new FileStream(physicalPath, FileMode.Create))
            {
                await stream.CopyToAsync(fs);
            }

            var doc = new Document
            {
                Id = Guid.NewGuid(),
                LandTitleId = landTitleId,
                PropertyId = propertyId,
                DocumentType = documentType,
                FileName = fileName,
                ContentType = contentType,
                Size = size,
                FilePath = $"/Uploads/{unique}",
                UploadedAt = uploadDate ?? DateTimeOffset.UtcNow,
                Description = description ?? string.Empty
            };

            return await _repository.AddAsync(doc);
        }
    }
}
