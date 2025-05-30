using ExpenseControlApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControlApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/expensedetails")]
public class ExpenseDetailsController : ControllerBase
{
    private readonly IExpenseDetailService _expenseDetailService;

    public ExpenseDetailsController(IExpenseDetailService expenseDetailService)
    {
        _expenseDetailService = expenseDetailService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var details = await _expenseDetailService.GetAllAsync();
        return Ok(details);
    }
}
