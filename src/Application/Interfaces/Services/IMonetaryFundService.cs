// Requiere: MonetaryFundDto, MonetaryFundCreateDto, MonetaryFundUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IMonetaryFundService
{
    Task<List<MonetaryFundDto>> GetAllAsync(long userId);
    Task<MonetaryFundDto> AddAsync(long userId, MonetaryFundCreateDto dto);
    Task<MonetaryFundDto> UpdateAsync(long userId, MonetaryFundUpdateDto dto);
    Task<MonetaryFundDto?> GetByIdAsync(long id, long userId);
    // Task DeleteAsync(long id);
}
