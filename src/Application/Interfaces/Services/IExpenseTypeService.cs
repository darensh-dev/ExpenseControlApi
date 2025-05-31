using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IExpenseTypeService
{
    Task<List<ExpenseTypeDto>> GetAllAsync(long userId);
    Task<ExpenseTypeDto> AddAsync(ExpenseTypeCreateServiceDto dto);
    // Task<ExpenseTypeDto?> GetByIdAsync(long id);
    // Task UpdateAsync(long id, ExpenseTypeUpdateDto dto);
    // Task DeleteAsync(long id);
}
