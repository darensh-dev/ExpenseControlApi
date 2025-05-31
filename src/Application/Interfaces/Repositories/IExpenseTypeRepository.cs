using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IExpenseTypeRepository
{
    Task<ExpenseType?> GetByIdAsync(int id, long userId);
    Task<Dictionary<int, ExpenseType>> GetByIdsAsync(IEnumerable<int> ids);
    Task<List<ExpenseType>> GetAllAsync(long userId);
    Task<string> GenerateNextCodeAsync(long userId);
    Task AddAsync(ExpenseType entity);

    // Task UpdateAsync(ExpenseType entity);
    // Task DeleteAsync(long id);
}
