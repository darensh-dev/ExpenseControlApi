using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
}