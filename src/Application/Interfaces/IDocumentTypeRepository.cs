using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IDocumentTypeRepository
{
    Task AddAsync(DocumentType entity);
    Task<DocumentType?> GetByIdAsync(long id);
    Task<List<DocumentType>> GetAllAsync();
    Task UpdateAsync(DocumentType entity);
    Task DeleteAsync(long id);
}
