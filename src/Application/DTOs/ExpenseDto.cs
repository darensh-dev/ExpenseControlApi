using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenseControlApi.Application.DTOs;

public class ExpenseDto
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

    public List<ExpenseDetailDto> Details { get; set; } = new();
}

public class ExpenseCreateDto
{
    public long MonetaryFundId { get; set; }
    public DateOnly Date { get; set; }
    public string? MerchantName { get; set; }
    public int DocumentTypeId { get; set; }
    public string? OtherDocumentTypeText { get; set; }
    public string? Notes { get; set; }
    public List<ExpenseDetailCreateDto> Details { get; set; } = new();
}

public class ExpenseUpdateDto
{
    public long Id { get; set; }
    public long MonetaryFundId { get; set; }
    public DateOnly Date { get; set; }
    public string? MerchantName { get; set; }
    public int DocumentTypeId { get; set; }
    public string? OtherDocumentTypeText { get; set; }
    public string? Notes { get; set; }
}
