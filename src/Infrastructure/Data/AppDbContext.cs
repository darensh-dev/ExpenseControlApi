// src/Infrastructure/Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Attachment> Attachment => Set<Attachment>();
    public DbSet<AuditLog> AuditLog => Set<AuditLog>();
    public DbSet<Budget> Budget => Set<Budget>();
    public DbSet<Deposit> Deposit => Set<Deposit>();
    public DbSet<DocumentType> DocumentType => Set<DocumentType>();
    public DbSet<ExpenseDetail> ExpenseDetail => Set<ExpenseDetail>();
    public DbSet<ExpenseHeader> ExpenseHeader => Set<ExpenseHeader>();
    public DbSet<ExpenseType> ExpenseType => Set<ExpenseType>();
    public DbSet<FundType> FundType => Set<FundType>();
    public DbSet<LoginLog> LoginLog => Set<LoginLog>();
    public DbSet<MonetaryFund> MonetaryFund => Set<MonetaryFund>();
    public DbSet<User> User => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
