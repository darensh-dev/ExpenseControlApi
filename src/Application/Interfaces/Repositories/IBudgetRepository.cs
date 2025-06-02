using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IBudgetRepository
{
    Task<List<Budget>> GetAllAsync(long userId);
    Task<Budget?> GetByIdAsync(long id, long userId);
    Task<BudgetSummaryDto> GetByTypeAndMonthAsync(int expenseTypeId, long userId, DateOnly month);
    Task AddAsync(Budget entity);
    Task UpdateAsync(Budget entity);
}
