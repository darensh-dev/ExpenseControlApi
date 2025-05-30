// Requiere: DocumentTypeDto, DocumentTypeCreateDto, DocumentTypeUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IDocumentTypeService
{
    Task<List<DocumentTypeDto>> GetAllAsync();
    Task<DocumentTypeDto?> GetByIdAsync(long id);
    Task AddAsync(DocumentTypeCreateDto dto);
    Task UpdateAsync(long id, DocumentTypeUpdateDto dto);
    Task DeleteAsync(long id);
}
