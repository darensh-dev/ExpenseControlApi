// Application/Exceptions/BudgetExceededException.cs
using System;

namespace ExpenseControlApi.Application.Exceptions;

public class BudgetExceededException : Exception
{
    public int ExpenseTypeId { get; }
    public decimal Budget { get; }
    public decimal Projected { get; }

    public BudgetExceededException(int expenseTypeId, decimal budget, decimal projected)
        : base($"Overspent for type {expenseTypeId}: Budget={budget}, Projected={projected}")
    {
        ExpenseTypeId = expenseTypeId;
        Budget = budget;
        Projected = projected;
    }
}