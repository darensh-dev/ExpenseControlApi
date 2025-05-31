using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Application.DTOs;

public class FundTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}


public class FundTypeCreateApiDto
{
    public string Name { get; set; } = null!;
}


public class FundTypeCreateServiceDto
{
    public string Name { get; set; } = null!;
    public long CreatedByUserId { get; set; }
}
