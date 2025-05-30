using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IDocumentTypeRepository
{
    Task<List<DocumentType>> GetAllAsync(long currentUserId);
    // Task AddAsync(DocumentType entity);
    // Task<DocumentType?> GetByIdAsync(long id);
    // Task UpdateAsync(DocumentType entity);
    // Task DeleteAsync(long id);
}
