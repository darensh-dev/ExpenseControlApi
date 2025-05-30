// Requiere: MonetaryFundDto, MonetaryFundCreateDto, MonetaryFundUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IMonetaryFundService
{
    Task<List<MonetaryFundDto>> GetAllAsync();
    Task<MonetaryFundDto?> GetByIdAsync(long id);
    Task AddAsync(MonetaryFundCreateDto dto);
    Task UpdateAsync(long id, MonetaryFundUpdateDto dto);
    Task DeleteAsync(long id);
}
