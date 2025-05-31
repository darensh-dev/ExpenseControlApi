// Requiere: BudgetDto, BudgetCreateDto, BudgetUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IBudgetService
{
    Task<List<BudgetDto>> GetAllAsync(long userId);
    Task<BudgetDto?> GetByIdAsync(long id, long userId);
    Task<BudgetDto> AddAsync(long userId, BudgetCreateDto dto);
    Task<BudgetDto> UpdateAsync(long userId, BudgetUpdateDto dto);
    Task DeleteAsync(long id, long userId);
}
