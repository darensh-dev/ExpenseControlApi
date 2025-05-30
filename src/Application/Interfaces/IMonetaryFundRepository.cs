using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IMonetaryFundRepository
{
    Task AddAsync(MonetaryFund entity);
    Task<MonetaryFund?> GetByIdAsync(long id);
    Task<List<MonetaryFund>> GetAllAsync();
    Task UpdateAsync(MonetaryFund entity);
    Task DeleteAsync(long id);
}
