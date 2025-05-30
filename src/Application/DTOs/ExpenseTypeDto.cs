using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Application.DTOs;

public class ExpenseTypeDto
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}

public class ExpenseTypeCreateApiDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public class ExpenseTypeCreateServiceDto
{

    public long CreatedByUserId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}

