// Requiere: DepositDto, DepositCreateDto, DepositUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IDepositService
{
    Task<List<DepositDto>> GetAllAsync();
    Task<DepositDto?> GetByIdAsync(long id);
    Task AddAsync(DepositCreateDto dto);
    Task UpdateAsync(long id, DepositUpdateDto dto);
    Task DeleteAsync(long id);
}
