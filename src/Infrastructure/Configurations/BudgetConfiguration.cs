// src/Infrastructure/Data/Configurations/BudgetConfiguration.cs
using ExpenseControlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControlApi.Infrastructure.Data.Configurations;

public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> entity)
    {
        entity.HasKey(e => e.Id).HasName("budgets__pk");

        entity.ToTable("budgets");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.Amount)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("amount");
        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("created_at");
        entity.Property(e => e.DeletedAt)
            .HasColumnType("datetime")
            .HasColumnName("deleted_at");
        entity.Property(e => e.ExpenseTypeId).HasColumnName("expense_type_id");
        entity.Property(e => e.Month).HasColumnName("month");
        entity.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");
        entity.Property(e => e.UserId).HasColumnName("user_id");

        entity.HasOne(d => d.ExpenseType).WithMany(p => p.Budgets)
            .HasForeignKey(d => d.ExpenseTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("budgets__expense_type_id_fk");

        entity.HasOne(d => d.User).WithMany(p => p.Budgets)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("budgets__user_id_fk");
    }
}


