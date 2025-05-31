using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IFundTypeRepository
{
    Task AddAsync(FundType entity);
    Task<List<FundType>> GetAllAsync(long userId);
    Task<FundType?> GetByIdAsync(int id, long userId);
    // Task UpdateAsync(FundType entity);
    // Task DeleteAsync(long id);
}
