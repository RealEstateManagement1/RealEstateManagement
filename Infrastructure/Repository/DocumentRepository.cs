using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _db;

        public DocumentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Document> AddAsync(Document document)
        {
            _db.Documents.Add(document);
            await _db.SaveChangesAsync();
            return document;
        }

        public async Task DeleteAsync(Guid id)
        {
            var d = await _db.Documents.FindAsync(id);
            if (d is not null)
            {
                _db.Documents.Remove(d);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Document>> GetAllAsync()
        {
            return await _db.Documents.ToListAsync();
        }

        public async Task<Document?> GetByIdAsync(Guid id)
        {
            return await _db.Documents.FindAsync(id);
        }
    }
}
