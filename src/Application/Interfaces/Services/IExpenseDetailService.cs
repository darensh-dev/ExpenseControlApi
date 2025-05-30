// Requiere: ExpenseDetailDto, ExpenseDetailCreateDto, ExpenseDetailUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IExpenseDetailService
{
    Task<List<ExpenseDetailDto>> GetAllAsync();
    Task<ExpenseDetailDto?> GetByIdAsync(long id);
    Task AddAsync(ExpenseDetailCreateDto dto);
    Task UpdateAsync(long id, ExpenseDetailUpdateDto dto);
    Task DeleteAsync(long id);
}
