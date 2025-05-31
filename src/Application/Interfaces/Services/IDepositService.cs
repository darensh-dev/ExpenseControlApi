// Requiere: DepositDto, DepositCreateDto, DepositUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IDepositService
{
    Task<List<DepositDto>> GetByDateAsync(long userId, long year, long month);
    Task<DepositDto?> GetByIdAsync(long id, long userId);
    Task<DepositDto> AddAsync(long userId, DepositCreateDto dto);
    Task DeleteAsync(long id, long userId);
    // Task UpdateAsync(long id, DepositUpdateDto dto);
}
