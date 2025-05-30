using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IAuditLogRepository
{
    Task AddAsync(AuditLog entity);
    Task<AuditLog?> GetByIdAsync(long id);
    Task<List<AuditLog>> GetAllAsync();
    Task UpdateAsync(AuditLog entity);
    Task DeleteAsync(long id);
}
