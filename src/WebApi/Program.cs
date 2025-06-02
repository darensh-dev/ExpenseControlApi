using ExpenseControlApi.Application.DependencyInjection;
using ExpenseControlApi.Infrastructure.DependencyInjection;
using ExpenseControlApi.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000);
});

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5173",
        builder => builder.WithOrigins("https://expense-control-frontend-gqvires17-darens-projects-8738ee1d.vercel.app")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials()
                          );
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ApiExceptionHandlingMiddleware>();

app.UseCors("AllowLocalhost5173");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
