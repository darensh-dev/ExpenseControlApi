// Requiere: ExpenseHeaderDto, ExpenseHeaderCreateDto, ExpenseHeaderUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IExpenseService
{
    Task<ExpenseDto?> GetByIdAsync(long id, long userId);
    Task<List<ExpenseDto>> GetByDateAsync(long userId, int year, int month);
    Task<ExpenseDto> CreateAsync(long userId, ExpenseCreateDto dto);
}
