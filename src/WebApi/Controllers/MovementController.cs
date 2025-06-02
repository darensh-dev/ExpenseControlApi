using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ExpenseControlApi.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/v1")]
public class MovementController : ControllerBase
{
    private readonly IMovementService _movimentService;

    public MovementController(IMovementService movimentService)
    {
        _movimentService = movimentService;
    }

    [HttpGet]
    [Route("budget-execution")]
    public async Task<IActionResult> GetAllBudgetExecution([FromQuery] DateRangeFilterDto dto)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!long.TryParse(userIdString, out var userId))
        {
            return BadRequest("Invalid user ID in token");
        }
        var users = await _movimentService.GetBudgetExecutionAsync(userId, dto);
        return Ok(users);
    }

    [HttpGet]
    [Route("movement")]
    public async Task<IActionResult> GetAllMoviment([FromQuery] DateRangeFilterDto dto)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!long.TryParse(userIdString, out var userId))
        {
            return BadRequest("Invalid user ID in token");
        }
        var users = await _movimentService.GetAllMovimentAsync(userId, dto);
        return Ok(users);
    }

}
