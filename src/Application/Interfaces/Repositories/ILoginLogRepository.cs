// Application/Interfaces/ILoginLogRepository.cs
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Interfaces;

public interface ILoginLogRepository
{
    Task AddAsync(LoginLog log);
}
