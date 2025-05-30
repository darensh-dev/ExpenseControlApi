using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Domain.Entities;

public partial class FundType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public long? CreatedByUserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User? CreatedByUser { get; set; }

    public virtual ICollection<MonetaryFund> MonetaryFunds { get; set; } = new List<MonetaryFund>();
}
