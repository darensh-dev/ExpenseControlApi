// src/Infrastructure/Data/Configurations/DepositConfiguration.cs
using ExpenseControlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControlApi.Infrastructure.Data.Configurations;

public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
{
    public void Configure(EntityTypeBuilder<Deposit> entity)
    {
        entity.HasKey(e => e.Id).HasName("deposits__pk");

        entity.ToTable("deposits");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.Amount)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("amount");
        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("created_at");
        entity.Property(e => e.Date).HasColumnName("date");
        entity.Property(e => e.DeletedAt)
            .HasColumnType("datetime")
            .HasColumnName("deleted_at");
        entity.Property(e => e.MonetaryFundId).HasColumnName("monetary_fund_id");
        entity.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");
        entity.Property(e => e.UserId).HasColumnName("user_id");

        entity.HasOne(d => d.MonetaryFund).WithMany(p => p.Deposits)
            .HasForeignKey(d => d.MonetaryFundId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("deposits__monetary_fund_id_fk");

        entity.HasOne(d => d.User).WithMany(p => p.Deposits)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("deposits__user_id_fk");
    }
}


