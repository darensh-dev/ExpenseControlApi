// src/Domain/Entities/Users.cs
using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Domain.Entities;

public partial class User
{
    public long Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();

    public virtual ICollection<DocumentType> DocumentTypes { get; set; } = new List<DocumentType>();

    public virtual ICollection<ExpenseHeader> ExpenseHeaders { get; set; } = new List<ExpenseHeader>();

    public virtual ICollection<ExpenseType> ExpenseTypes { get; set; } = new List<ExpenseType>();

    public virtual ICollection<FundType> FundTypes { get; set; } = new List<FundType>();

    public virtual ICollection<MonetaryFund> MonetaryFunds { get; set; } = new List<MonetaryFund>();
}
