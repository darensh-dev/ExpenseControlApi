using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Domain.Entities;

public partial class Budget
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public int ExpenseTypeId { get; set; }

    public DateOnly Month { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ExpenseType ExpenseType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
