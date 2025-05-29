namespace ExpenseControlApi.Domain.Entities;

public class User
{
    public long ID { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int RegisterState { get; set; }
}
