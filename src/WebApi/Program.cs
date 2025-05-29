using ExpenseControlApi.Infrastructure.Data;
using ExpenseControlApi.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); // <== ¡Importante!
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Aquí puedes registrar tus servicios si los tienes
// builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<UserService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization(); // <== Esto también es importante si tienes auth

app.MapControllers(); // <== ¡Necesario para mapear tus [ApiController]!

app.Run();
