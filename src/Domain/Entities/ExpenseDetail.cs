using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Domain.Entities;

public partial class ExpenseDetail
{
    public long Id { get; set; }

    public long ExpenseHeaderId { get; set; }

    public int ExpenseTypeId { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ExpenseHeader ExpenseHeader { get; set; } = null!;

    public virtual ExpenseType ExpenseType { get; set; } = null!;
}
