using ExpenseControlApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/deposit")]
public class DepositsController : ControllerBase
{
    private readonly IDepositService _depositService;

    public DepositsController(IDepositService depositService)
    {
        _depositService = depositService;
    }

    [HttpGet]
    public async Task<IActionResult> GetByDate([FromQuery] DepositGetDto dto)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!long.TryParse(userIdString, out var userId))
        {
            return BadRequest("Invalid user ID in token");
        }
        var funds = await _depositService.GetByDateAsync(userId, dto.Year, dto.Month);
        if (!funds.Any())
        {
            return NoContent();
        }
        return Ok(funds);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!long.TryParse(userIdString, out var userId))
        {
            return BadRequest("Invalid user ID in token");
        }

        var fund = await _depositService.GetByIdAsync(id, userId);
        if (fund == null)
        {
            return NotFound(new { message = "Deposit fund not found" });
        }

        return Ok(fund);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DepositCreateDto dto)
    {
        try
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!long.TryParse(userIdString, out var userId))
            {
                return BadRequest("Invalid user ID in token");
            }
            var deposit = new DepositCreateDto
            {
                MonetaryFundId = dto.MonetaryFundId,
                Date = dto.Date,
                Amount = dto.Amount,
            };
            var created = await _depositService.AddAsync(userId, deposit);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
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
            await _depositService.DeleteAsync(id, userId);
            return Ok(new { message = "Deposit remove successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
