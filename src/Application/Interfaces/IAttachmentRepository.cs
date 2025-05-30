using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IAttachmentRepository
{
    Task AddAsync(Attachment entity);
    Task<Attachment?> GetByIdAsync(long id);
    Task<List<Attachment>> GetAllAsync();
    Task UpdateAsync(Attachment entity);
    Task DeleteAsync(long id);
}
