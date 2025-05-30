// Archivo: src/Application/Services/AttachmentService.cs
using ExpenseControlApi.Application.DTOs;
// using ExpenseControlApi.Application.Interfaces.Repositories;
// using ExpenseControlApi.Application.Interfaces.Services
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class AttachmentService // : IAttachmentService
{
    private readonly IAttachmentRepository _repository;

    public AttachmentService(IAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AttachmentDto>> GetAllAsync()
{
    var entities = await _repository.GetAllAsync();
    return entities.Select(e => new AttachmentDto
    {
        Id = e.Id,
        ExpenseHeaderId = e.ExpenseHeaderId,
        FileName = e.FileName,
        FileUrl = e.FileUrl,
        ContentType = e.ContentType,
        UploadedByUserId = e.UploadedByUserId,
        CreatedAt = e.CreatedAt,
        UpdatedAt = e.UpdatedAt,
        DeletedAt = e.DeletedAt
    }).ToList();
}

public async Task<AttachmentDto?> GetByIdAsync(long id)
{
    var entity = await _repository.GetByIdAsync(id);
    if (entity == null) return null;
    return new AttachmentDto
    {
        Id = entity.Id,
        ExpenseHeaderId = entity.ExpenseHeaderId,
        FileName = entity.FileName,
        FileUrl = entity.FileUrl,
        ContentType = entity.ContentType,
        UploadedByUserId = entity.UploadedByUserId,
        CreatedAt = entity.CreatedAt,
        UpdatedAt = entity.UpdatedAt,
        DeletedAt = entity.DeletedAt
    };
}

public async Task AddAsync(AttachmentCreateDto dto)
{
    var entity = new Attachment
    {
        ExpenseHeaderId = dto.ExpenseHeaderId,
        FileName = dto.FileName,
        FileUrl = dto.FileUrl,
        ContentType = dto.ContentType,
        UploadedByUserId = dto.UploadedByUserId,
        CreatedAt = DateTime.UtcNow
    };
    await _repository.AddAsync(entity);
}

public async Task UpdateAsync(long id, AttachmentUpdateDto dto)
{
    var entity = await _repository.GetByIdAsync(id);
    if (entity == null) throw new Exception("Attachment not found");
    if (dto.FileName != null) entity.FileName = dto.FileName;
    if (dto.FileUrl != null) entity.FileUrl = dto.FileUrl;
    if (dto.ContentType != null) entity.ContentType = dto.ContentType;
    entity.UpdatedAt = dto.UpdatedAt ?? DateTime.UtcNow;
    entity.DeletedAt = dto.DeletedAt;
    await _repository.UpdateAsync(entity);
}

public async Task DeleteAsync(long id)
{
    await _repository.DeleteAsync(id);
}
}
