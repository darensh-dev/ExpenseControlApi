using ExpenseControlApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/monetary-fund")]
public class MonetaryFundsController : ControllerBase
{
    private readonly IMonetaryFundService _monetaryFundService;

    public MonetaryFundsController(IMonetaryFundService monetaryFundService)
    {
        _monetaryFundService = monetaryFundService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!long.TryParse(userIdString, out var userId))
        {
            return BadRequest("Invalid user ID in token");
        }
        var funds = await _monetaryFundService.GetAllAsync(userId);
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

        var fund = await _monetaryFundService.GetByIdAsync(id, userId);
        if (fund == null)
        {
            return NotFound(new { message = "Monetary fund not found" });
        }

        return Ok(fund);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MonetaryFundCreateDto dto)
    {
        try
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!long.TryParse(userIdString, out var userId))
            {
                return BadRequest("Invalid user ID in token");
            }
            var monetaryFund = new MonetaryFundCreateDto
            {
                Name = dto.Name,
                FundTypeId = dto.FundTypeId,
                InitialBalance = dto.InitialBalance,
            };
            var created = await _monetaryFundService.AddAsync(userId, monetaryFund);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] MonetaryFundUpdateDto dto)
    {
        try
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!long.TryParse(userIdString, out var userId))
            {
                return BadRequest("Invalid user ID in token");
            }

            var monetaryFund = new MonetaryFundUpdateDto
            {
                Id = dto.Id,
                Name = dto.Name,
                FundTypeId = dto.FundTypeId,
                InitialBalance = dto.InitialBalance,
            };

            var updated = await _monetaryFundService.UpdateAsync(userId, monetaryFund);
            return Ok(updated);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
