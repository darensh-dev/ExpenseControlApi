using ExpenseControlApi.Application.Exceptions;

namespace ExpenseControlApi.WebApi.Middleware;

public class ApiExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ApiExceptionHandlingMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BudgetExceededException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            var problemDetails = new
            {
                type = "https://httpstatuses.com/400",
                title = "Budget Exceeded",
                detail = ex.Message,
                status = 400,
                expenseTypeId = ex.ExpenseTypeId,
                budget = ex.Budget,
                projected = ex.Projected
            };

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new
            {
                type = "https://httpstatuses.com/500",
                title = "Internal Server Error",
                detail = ex.Message,
                status = 500
            });
        }
    }
}
