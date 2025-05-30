using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Domain.Entities;

public partial class Attachment
{
    public long Id { get; set; }

    public long ExpenseHeaderId { get; set; }

    public string FileName { get; set; } = null!;

    public string FileUrl { get; set; } = null!;

    public string? ContentType { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ExpenseHeader ExpenseHeader { get; set; } = null!;
}