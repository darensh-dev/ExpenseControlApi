using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Application.DTOs;

public class MonetaryFundDto
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal InitialBalance { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public FundTypeDto FundType { get; set; } = new();

}

public class MonetaryFundCreateDto
{
    public int FundTypeId { get; set; }
    public string Name { get; set; } = null!;
    public decimal InitialBalance { get; set; }
}

public class MonetaryFundUpdateDto
{
    public long Id { get; set; }
    public int? FundTypeId { get; set; }
    public string? Name { get; set; }
    public decimal? InitialBalance { get; set; }
}

public class MonetaryFundDeleteDto
{
    public long Id { get; set; }
}