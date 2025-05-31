using ExpenseControlApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/fund-types")]
public class FundTypesController : ControllerBase
{
    private readonly IFundTypeService _fundTypeService;

    public FundTypesController(IFundTypeService fundTypeService)
    {
        _fundTypeService = fundTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!long.TryParse(userIdString, out var userId))
        {
            return BadRequest("Invalid user ID in token");
        }

        var types = await _fundTypeService.GetAllAsync(userId);
        if (!types.Any())
        {
            return NoContent();
        }
        return Ok(types);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FundTypeCreateApiDto dto)
    {
        try
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!long.TryParse(userIdString, out var userId))
            {
                return BadRequest("Invalid user ID in token");
            }
            var entity = new FundTypeCreateServiceDto
            {
                Name = dto.Name,
                CreatedByUserId = userId,
            };
            var created = await _fundTypeService.AddAsync(entity);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
