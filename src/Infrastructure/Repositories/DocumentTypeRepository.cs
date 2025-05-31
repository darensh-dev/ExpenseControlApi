// src/Infrastructure/Repositories/DocumentTypeRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControlApi.Infrastructure.Repositories;

public class DocumentTypeRepository : IDocumentTypeRepository
{
    private readonly AppDbContext _context;

    public DocumentTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DocumentType>> GetAllAsync(long currentUserId)
    {
        return await _context.DocumentType
            .Where(
                dt => dt.DeletedAt == null &&
                (
                    dt.CreatedByUserId == null
                    || dt.CreatedByUserId == currentUserId
                )
            )
            .ToListAsync();
    }
}
