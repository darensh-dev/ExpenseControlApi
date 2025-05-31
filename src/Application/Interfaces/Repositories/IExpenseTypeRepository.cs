using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IExpenseTypeRepository
{
    Task AddAsync(ExpenseType entity);
    Task<List<ExpenseType>> GetAllAsync(long userId);
    Task<string> GenerateNextCodeAsync(long userId);
    Task<Dictionary<int, ExpenseType>> GetByIdsAsync(IEnumerable<int> ids);

    // Task<ExpenseType?> GetByIdAsync(long id);
    // Task UpdateAsync(ExpenseType entity);
    // Task DeleteAsync(long id);
}
