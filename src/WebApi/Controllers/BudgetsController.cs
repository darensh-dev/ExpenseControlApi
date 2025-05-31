using ExpenseControlApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.WebApi.Controllers;


[Authorize]
[ApiController]
[Route("api/v1/budgets")]
public class BudgetsController : ControllerBase
{
    private readonly IBudgetService _budgetService;

    public BudgetsController(IBudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!long.TryParse(userIdString, out var userId))
        {
            return BadRequest("Invalid user ID in token");
        }
        var budgets = await _budgetService.GetAllAsync(userId);
        if (!budgets.Any())
        {
            return NoContent();
        }
        return Ok(budgets);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!long.TryParse(userIdString, out var userId))
        {
            return BadRequest("Invalid user ID in token");
        }

        var fund = await _budgetService.GetByIdAsync(id, userId);
        if (fund == null)
        {
            return NotFound(new { message = "Dudget not found" });
        }

        return Ok(fund);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BudgetCreateDto dto)
    {
        try
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!long.TryParse(userIdString, out var userId))
            {
                return BadRequest("Invalid user ID in token");
            }
            var budget = new BudgetCreateDto
            {
                ExpenseTypeId = dto.ExpenseTypeId,
                Month = dto.Month,
                Amount = dto.Amount,
            };
            var created = await _budgetService.AddAsync(userId, budget);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] BudgetUpdateDto dto)
    {
        try
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!long.TryParse(userIdString, out var userId))
            {
                return BadRequest("Invalid user ID in token");
            }

            var budget = new BudgetUpdateDto
            {
                Id = dto.Id,
                ExpenseTypeId = dto.ExpenseTypeId,
                Month = dto.Month,
                Amount = dto.Amount,
            };

            var updated = await _budgetService.UpdateAsync(userId, budget);
            return Ok(updated);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!long.TryParse(userIdString, out var userId))
            {
                return BadRequest("Invalid user ID in token");
            }
            await _budgetService.DeleteAsync(id, userId);
            return Ok(new { message = "Budget remove successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
