using ExpenseControlApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ExpenseControlApi.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace ExpenseControlApi.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/expense")]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseService _expenseService;

    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!long.TryParse(userIdString, out var userId))
        {
            return BadRequest("Invalid user ID in token");
        }
        var result = await _expenseService.GetByIdAsync(id, userId);
        if (result == null)
            return NoContent();

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetByDate([FromQuery] int year, [FromQuery] int month)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!long.TryParse(userIdString, out var userId))
        {
            return BadRequest("Invalid user ID in token");
        }
        var result = await _expenseService.GetByDateAsync(userId, year, month);
        if (result.Count == 0)
            return NoContent();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ExpenseCreateDto dto)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!long.TryParse(userIdString, out var userId))
        {
            return BadRequest("Invalid user ID in token");
        }
        var created = await _expenseService.CreateAsync(userId, dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id, userId = created.UserId }, created);
    }
}
