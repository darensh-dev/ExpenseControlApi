// Application/Services/AuthService.cs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Services.Auth;

namespace ExpenseControlApi.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ILoginLogRepository _loginLogRepository;
    private readonly TokenService _tokenService;

    public AuthService(
        IUserRepository userRepository,
        ILoginLogRepository loginLogRepository,
        TokenService tokenService)
    {
        _userRepository = userRepository;
        _loginLogRepository = loginLogRepository;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto dto, string? ip)
    {
        var user = await _userRepository.GetByUsernameAsync(dto.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
        {
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        var (token, expiresAt) = _tokenService.GenerateToken(user);

        await _loginLogRepository.AddAsync(new LoginLog
        {
            UserId = user.Id,
            Token = token,
            Ip = ip,
            CreatedAt = DateTime.UtcNow
        });

        return new LoginResponseDto
        {
            Token = token,
            Expiration = expiresAt
        };
    }
}
