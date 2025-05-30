using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Domain.Entities;

public partial class ExpenseHeader
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long MonetaryFundId { get; set; }

    public DateOnly Date { get; set; }

    public string? MerchantName { get; set; }

    public int DocumentTypeId { get; set; }

    public string? OtherDocumentTypeText { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual ICollection<ExpenseDetail> ExpenseDetails { get; set; } = new List<ExpenseDetail>();

    public virtual MonetaryFund MonetaryFund { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
