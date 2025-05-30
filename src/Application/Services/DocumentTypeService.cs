// Archivo: src/Application/Services/DocumentTypeService.cs
// Requiere: DocumentTypeDto, DocumentTypeCreateDto, DocumentTypeUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces.Repositories;
using ExpenseControlApi.Application.Interfaces.Services;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class DocumentTypeService : IDocumentTypeService
{
    private readonly IDocumentTypeRepository _repository;

    public DocumentTypeService(IDocumentTypeRepository repository)
    {
        _repository = repository;
    }

    // Métodos CRUD aquí (implementación pendiente)
}
