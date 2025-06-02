namespace ExpenseControlApi.Application.DTOs;

public class MovementDto
{
    public string MovementType { get; set; } = null!;
    public DateTime MovementDate { get; set; }
    public string FundName { get; set; } = null!;
    public string? DocumentType { get; set; }
    public string? TradeName { get; set; }
    public string? ExpenseType { get; set; }
    public decimal Amount { get; set; }
    public string? Notes { get; set; }
}

public class BudgetExecutionDto
{
    public string ExpenseType { get; set; } = null!;
    public decimal BudgetedAmount { get; set; }
    public decimal ExecutedAmount { get; set; }
}

public class DateRangeFilterDto
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}

