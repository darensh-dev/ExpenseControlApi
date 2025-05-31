using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenseControlApi.Application.DTOs;

public class BudgetDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public int ExpenseTypeId { get; set; }
    public DateOnly Month { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}

public class BudgetCreateDto
{
    public int ExpenseTypeId { get; set; }
    public DateOnly Month { get; set; }
    public decimal Amount { get; set; }

}

public class BudgetUpdateDto
{
    public long Id { get; set; }
    public int ExpenseTypeId { get; set; }
    public DateOnly Month { get; set; }
    public decimal Amount { get; set; }
}


