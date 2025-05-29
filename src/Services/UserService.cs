using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Infrastructure.Data;
using ExpenseControlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace ExpenseControlApi.Services;

public class UserService
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
            RegisterState = u.RegisterState
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
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            RegisterState = 1
        };

        await _userRepository.AddAsync(user);
    }
}
