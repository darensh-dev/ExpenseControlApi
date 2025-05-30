// src/Infrastructure/Data/Configurations/ExpenseDetailConfiguration.cs
using ExpenseControlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControlApi.Infrastructure.Data.Configurations;

public class ExpenseDetailConfiguration : IEntityTypeConfiguration<ExpenseDetail>
{
    public void Configure(EntityTypeBuilder<ExpenseDetail> entity)
    {
        entity.HasKey(e => e.Id).HasName("expense_details__pk");

        entity.ToTable("expense_details");

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
        entity.Property(e => e.ExpenseHeaderId).HasColumnName("expense_header_id");
        entity.Property(e => e.ExpenseTypeId).HasColumnName("expense_type_id");
        entity.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");

        entity.HasOne(d => d.ExpenseHeader).WithMany(p => p.ExpenseDetails)
            .HasForeignKey(d => d.ExpenseHeaderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("expense_details__expense_header_id_fk");

        entity.HasOne(d => d.ExpenseType).WithMany(p => p.ExpenseDetails)
            .HasForeignKey(d => d.ExpenseTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("expense_details__expense_type_id_fk");
    }
}


