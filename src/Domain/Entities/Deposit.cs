using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Domain.Entities;

public partial class Deposit
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long MonetaryFundId { get; set; }

    public DateOnly Date { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual MonetaryFund MonetaryFund { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
