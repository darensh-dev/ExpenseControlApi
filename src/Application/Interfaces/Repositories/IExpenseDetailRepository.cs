using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IExpenseDetailRepository
{
    Task AddAsync(ExpenseDetail entity);
    Task<ExpenseDetail?> GetByIdAsync(long id);
    Task<List<ExpenseDetail>> GetAllAsync();
    Task UpdateAsync(ExpenseDetail entity);
    Task DeleteAsync(long id);
}
