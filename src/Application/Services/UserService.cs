using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces.Repositories;
using ExpenseControlApi.Application.Interfaces.Services;
using ExpenseControlApi.Domain.Entities;


namespace ExpenseControlApi.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Username = u.Username,
            CreatedAt = u.CreatedAt,
        }).ToList();
    }

    public async Task RegisterAsync(UserRegisterDto dto)
    {
        var existing = await _userRepository.GetByUsernameAsync(dto.Username);
        if (existing != null)
        {
            throw new Exception("Username already taken");
        }

        var user = new User
        {
            Username = dto.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
        };

        await _userRepository.AddAsync(user);
    }
}
