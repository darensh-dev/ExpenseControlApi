// src/Infrastructure/Data/Configurations/ExpenseTypeConfiguration.cs
using ExpenseControlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControlApi.Infrastructure.Data.Configurations;

public class ExpenseTypeConfiguration : IEntityTypeConfiguration<ExpenseType>
{
    public void Configure(EntityTypeBuilder<ExpenseType> entity)
    {
        entity.HasKey(e => e.Id).HasName("expense_types__pk");

        entity.ToTable("expense_types");

        entity.HasIndex(e => e.Code, "expense_types__code_uq").IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.Code)
            .HasMaxLength(10)
            .HasColumnName("code");
        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("created_at");
        entity.Property(e => e.DeletedAt)
            .HasColumnType("datetime")
            .HasColumnName("deleted_at");
        entity.Property(e => e.Description)
            .HasMaxLength(500)
            .HasColumnName("description");
        entity.Property(e => e.Name)
            .HasMaxLength(150)
            .HasColumnName("name");
        entity.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");
    }
}
