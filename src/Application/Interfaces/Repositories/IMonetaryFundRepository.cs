using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IMonetaryFundRepository
{
    Task<MonetaryFund?> GetByIdAsync(long id);
    Task<List<MonetaryFund>> GetAllAsync(long userId);
    Task AddAsync(MonetaryFund entity);
    Task UpdateAsync(MonetaryFund entity);
    // Task DeleteAsync(long id);
}
