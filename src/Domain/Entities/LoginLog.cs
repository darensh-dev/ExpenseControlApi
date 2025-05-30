using System;
using System.Collections.Generic;

namespace ExpenseControlApi.Domain.Entities;

public partial class LoginLog
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string Token { get; set; } = null!;

    public string? Ip { get; set; }

    public DateTime CreatedAt { get; set; }
}
