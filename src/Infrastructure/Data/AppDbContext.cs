// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<User>().Property(u => u.ID).HasColumnName("ID");
        modelBuilder.Entity<User>().Property(u => u.Username).HasColumnName("username");
        modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("password");
        modelBuilder.Entity<User>().Property(u => u.CreatedAt).HasColumnName("created_at");
        modelBuilder.Entity<User>().Property(u => u.UpdatedAt).HasColumnName("updated_at");
        modelBuilder.Entity<User>().Property(u => u.RegisterState).HasColumnName("register_state");
    }
}
