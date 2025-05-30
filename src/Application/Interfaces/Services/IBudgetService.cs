// Requiere: BudgetDto, BudgetCreateDto, BudgetUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IBudgetService
{
    Task<List<BudgetDto>> GetAllAsync();
    Task<BudgetDto?> GetByIdAsync(long id);
    Task AddAsync(BudgetCreateDto dto);
    Task UpdateAsync(long id, BudgetUpdateDto dto);
    Task DeleteAsync(long id);
}
