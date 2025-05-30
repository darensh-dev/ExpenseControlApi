using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IBudgetRepository
{
    Task AddAsync(Budget entity);
    Task<Budget?> GetByIdAsync(long id);
    Task<List<Budget>> GetAllAsync();
    Task UpdateAsync(Budget entity);
    Task DeleteAsync(long id);
}
