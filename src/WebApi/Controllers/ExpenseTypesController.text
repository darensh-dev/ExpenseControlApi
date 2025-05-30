using ExpenseControlApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControlApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/expensetypes")]
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
        var types = await _expenseTypeService.GetAllAsync();
        return Ok(types);
    }
}
