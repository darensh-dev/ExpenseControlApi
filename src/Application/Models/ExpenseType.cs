// Models/ExpenseType.cs
namespace ExpenseControlApi.Models;

public class ExpenseType
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
