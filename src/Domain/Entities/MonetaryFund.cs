using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Domain.Entities;

public partial class MonetaryFund
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public int FundTypeId { get; set; }

    public string Name { get; set; } = null!;

    public decimal InitialBalance { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();

    public virtual ICollection<ExpenseHeader> ExpenseHeaders { get; set; } = new List<ExpenseHeader>();

    public virtual FundType FundType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
