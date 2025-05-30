using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Domain.Entities;

public partial class AuditLog
{
    public long Id { get; set; }

    public string TableName { get; set; } = null!;

    public long RecordId { get; set; }

    public string Action { get; set; } = null!;

    public long? ChangedByUserId { get; set; }

    public string? Changes { get; set; }

    public DateTime ChangeDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User? ChangedByUser { get; set; }
}
