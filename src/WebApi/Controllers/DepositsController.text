using ExpenseControlApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControlApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/deposits")]
public class DepositsController : ControllerBase
{
    private readonly IDepositService _depositService;

    public DepositsController(IDepositService depositService)
    {
        _depositService = depositService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var deposits = await _depositService.GetAllAsync();
        return Ok(deposits);
    }
}
