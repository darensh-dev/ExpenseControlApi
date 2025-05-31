using ExpenseControlApi.Domain.Entities;
namespace ExpenseControlApi.Application.Interfaces;

public interface IExpenseRepository
{
    Task<ExpenseHeader?> GetByIdAsync(long id, long userId);
    Task<List<ExpenseHeader>> GetByDateAsync(long userId, int year, int month);
    Task<decimal> GetTotalSpentByTypeInMonthAsync(int expenseTypeId, long userId, DateOnly month);
    Task AddAsync(ExpenseHeader header, List<ExpenseDetail> details);
}
