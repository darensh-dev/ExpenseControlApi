using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IFundTypeService
{
    Task<List<FundTypeDto>> GetAllAsync(long userId);
    Task<FundTypeDto> AddAsync(FundTypeCreateServiceDto dto);
    // Task<FundTypeDto?> GetByIdAsync(long id);
    // Task UpdateAsync(long id, FundTypeUpdateDto dto);
    // Task DeleteAsync(long id);
}
