using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Application.DTOs;

public class DepositDto
{
    public long Id { get; set; }
    public long MonetaryFundId { get; set; }
    public DateOnly Date { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}

public class DepositGetDto
{
    public long Year { get; set; }
    public long Month { get; set; }
}

public class DepositCreateDto
{
    public long MonetaryFundId { get; set; }
    public DateOnly Date { get; set; }
    public decimal Amount { get; set; }
}

