using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IDocumentTypeService
{
    Task<List<DocumentTypeDto>> GetAllAsync(long currentUserId);
    // Task AddAsync(DocumentTypeCreateDto dto);
    // Task<DocumentTypeDto?> GetByIdAsync(long id);
    // Task UpdateAsync(long id, DocumentTypeUpdateDto dto);
    // Task DeleteAsync(long id);
}
