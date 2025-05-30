using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IDepositRepository
{
    Task AddAsync(Deposit entity);
    Task<Deposit?> GetByIdAsync(long id);
    Task<List<Deposit>> GetAllAsync();
    Task UpdateAsync(Deposit entity);
    Task DeleteAsync(long id);
}
