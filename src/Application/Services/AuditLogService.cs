// Archivo: src/Application/Services/AuditLogService.cs
// Requiere: AuditLogDto, AuditLogCreateDto, AuditLogUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces.Repositories;
using ExpenseControlApi.Application.Interfaces.Services;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class AuditLogService : IAuditLogService
{
    private readonly IAuditLogRepository _repository;

    public AuditLogService(IAuditLogRepository repository)
    {
        _repository = repository;
    }

    // Métodos CRUD aquí (implementación pendiente)
}
