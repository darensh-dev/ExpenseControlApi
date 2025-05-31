using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IExpenseRepository
{
    Task AddAsync(ExpenseHeader entity);
    Task<ExpenseHeader?> GetByIdAsync(long id);
    Task<List<ExpenseHeader>> GetAllAsync();
    Task UpdateAsync(ExpenseHeader entity);
    Task DeleteAsync(long id);
}
