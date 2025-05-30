// src/Infrastructure/Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Attachment> Attachments => Set<Attachment>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<Budget> Budgets => Set<Budget>();
    public DbSet<Deposit> Deposits => Set<Deposit>();
    public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();
    public DbSet<ExpenseDetail> ExpenseDetails => Set<ExpenseDetail>();
    public DbSet<ExpenseHeader> ExpenseHeaders => Set<ExpenseHeader>();
    public DbSet<ExpenseType> ExpenseTypes => Set<ExpenseType>();
    public DbSet<FundType> FundTypes => Set<FundType>();
    public DbSet<LoginLog> LoginLogs => Set<LoginLog>();
    public DbSet<MonetaryFund> MonetaryFunds => Set<MonetaryFund>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
