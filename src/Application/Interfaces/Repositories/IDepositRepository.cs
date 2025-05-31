using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface IDepositRepository
{
    Task<Deposit?> GetByIdAsync(long id, long userId);
    Task<List<Deposit>> GetByDateAsync(long userId, long year, long month);
    Task AddAsync(Deposit entity);
    Task DeleteAsync(long id, long userId);
}
