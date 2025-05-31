using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IBudgetRepository
{
    Task<List<Budget>> GetAllAsync(long userId);
    Task<Budget?> GetByIdAsync(long id, long userId);
    Task<Budget?> GetByTypeAndMonthAsync(int expenseTypeId, long userId, DateOnly month);
    Task AddAsync(Budget entity);
    Task UpdateAsync(Budget entity);
}
