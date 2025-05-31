using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace ExpenseControlApi.WebApi.Controllers;


[Authorize]
[ApiController]
[Route("api/v1/expense-types")]
public class ExpenseTypesController : ControllerBase
{
    private readonly IExpenseTypeService _expenseTypeService;

    public ExpenseTypesController(IExpenseTypeService expenseTypeService)
    {
        _expenseTypeService = expenseTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!long.TryParse(userIdString, out var userId))
        {
            return BadRequest("Invalid user ID in token");
        }
        var types = await _expenseTypeService.GetAllAsync(userId);

        if (!types.Any())
        {
            return NoContent();
        }
        return Ok(types);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ExpenseTypeCreateApiDto dto)
    {
        try
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!long.TryParse(userIdString, out var userId))
            {
                return BadRequest("Invalid user ID in token");
            }
            var expenseType = new ExpenseTypeCreateServiceDto
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedByUserId = userId,
                Code = ""
            };
            var created  = await _expenseTypeService.AddAsync(expenseType);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
