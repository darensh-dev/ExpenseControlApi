using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IExpenseTypeRepository
{
    Task AddAsync(ExpenseType entity);
    Task<ExpenseType?> GetByIdAsync(long id);
    Task<List<ExpenseType>> GetAllAsync();
    Task UpdateAsync(ExpenseType entity);
    Task DeleteAsync(long id);
}
