using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    [Required(ErrorMessage = "El campo 'Year' es obligatorio.")]
    [Range(2000, 2100, ErrorMessage = "El año debe estar entre 2000 y 2100.")]
    public long Year { get; set; }
    [Required(ErrorMessage = "El campo 'Month' es obligatorio.")]
    [Range(1, 12, ErrorMessage = "El mes debe estar entre 1 y 12.")]
    public long Month { get; set; }
}

public class DepositCreateDto
{
    public long MonetaryFundId { get; set; }
    public DateOnly Date { get; set; }
    public decimal Amount { get; set; }
}

