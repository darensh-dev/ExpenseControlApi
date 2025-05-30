namespace ExpenseControlApi.Application.DTOs;

public class UserDto
{
    public long Id { get; set; }
    public string Username { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}


public class UserCreateDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
