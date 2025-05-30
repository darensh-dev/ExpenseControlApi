using ExpenseControlApi.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControlApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/auditlogs")]
public class AuditLogsController : ControllerBase
{
    private readonly IAuditLogService _auditLogService;

    public AuditLogsController(IAuditLogService auditLogService)
    {
        _auditLogService = auditLogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var logs = await _auditLogService.GetAllAsync();
        return Ok(logs);
    }
}
