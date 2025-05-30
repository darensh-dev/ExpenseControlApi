// src/Infrastructure/Data/Configurations/MonetaryFundConfiguration.cs
using ExpenseControlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControlApi.Infrastructure.Data.Configurations;

public class MonetaryFundConfiguration : IEntityTypeConfiguration<MonetaryFund>
{
    public void Configure(EntityTypeBuilder<MonetaryFund> entity)
    {
        entity.HasKey(e => e.Id).HasName("monetary_funds__pk");

        entity.ToTable("monetary_funds");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("created_at");
        entity.Property(e => e.DeletedAt)
            .HasColumnType("datetime")
            .HasColumnName("deleted_at");
        entity.Property(e => e.FundTypeId).HasColumnName("fund_type_id");
        entity.Property(e => e.InitialBalance)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("initial_balance");
        entity.Property(e => e.Name)
            .HasMaxLength(150)
            .HasColumnName("name");
        entity.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");
        entity.Property(e => e.UserId).HasColumnName("user_id");

        entity.HasOne(d => d.FundType).WithMany(p => p.MonetaryFunds)
            .HasForeignKey(d => d.FundTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("monetary_funds__fund_type_id_fk");

        entity.HasOne(d => d.User).WithMany(p => p.MonetaryFunds)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("monetary_funds__user_id_fk");
    }
}


