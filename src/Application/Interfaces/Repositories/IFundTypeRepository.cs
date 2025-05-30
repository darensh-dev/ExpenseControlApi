using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IFundTypeRepository
{
    Task AddAsync(FundType entity);
    Task<FundType?> GetByIdAsync(long id);
    Task<List<FundType>> GetAllAsync();
    Task UpdateAsync(FundType entity);
    Task DeleteAsync(long id);
}
