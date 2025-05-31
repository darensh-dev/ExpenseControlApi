// Application/Exceptions/BudgetExceededException.cs
using System;

namespace ExpenseControlApi.Application.Exceptions;

public class BudgetExceededException : Exception
{
    public int ExpenseTypeId { get; }
    public string expenseTypeName { get; }
    public decimal Budget { get; }
    public decimal Projected { get; }

    public BudgetExceededException(int expenseTypeId, decimal budget, decimal projected, string expenseTypeName)
        : base($"Overspent for type {expenseTypeName} (ID {expenseTypeId}): Budget={budget}, Projected={projected}")
    {
        ExpenseTypeId = expenseTypeId;
        this.expenseTypeName = expenseTypeName;
        Budget = budget;
        Projected = projected;
    }
}