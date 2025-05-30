// src/Application/Services/DocumentTypeService.cs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class DocumentTypeService : IDocumentTypeService
{
    private readonly IDocumentTypeRepository _repository;

    public DocumentTypeService(IDocumentTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<DocumentTypeDto>> GetAllAsync (long currentUserId) {
        var DocumentType = await _repository.GetAllAsync(currentUserId);
        return DocumentType.Select(dt => new DocumentTypeDto
        {
            Id = dt.Id,
            Name = dt.Name,
        }).ToList();
    }
}
