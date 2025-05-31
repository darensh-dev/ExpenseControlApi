using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenseControlApi.Application.DTOs;

public class ExpenseDetailDto
{
    public long Id { get; set; }
    public long ExpenseHeaderId { get; set; }
    public int ExpenseTypeId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}

public class ExpenseDetailCreateDto
{
    public int ExpenseTypeId { get; set; }
    public decimal Amount { get; set; }

}

public class ExpenseDetailUpdateDto
{
    public long Id { get; set; }
    public int ExpenseTypeId { get; set; }
    public decimal Amount { get; set; }
}


