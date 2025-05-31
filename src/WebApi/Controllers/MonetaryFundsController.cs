using ExpenseControlApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControlApi.WebApi.Controllers;

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
        var funds = await _monetaryFundService.GetAllAsync();
        return Ok(funds);
    }
}
