// src/Infrastructure/Data/Configurations/FundTypeConfiguration.cs
using ExpenseControlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControlApi.Infrastructure.Data.Configurations;

public class FundTypeConfiguration : IEntityTypeConfiguration<FundType>
{
    public void Configure(EntityTypeBuilder<FundType> entity)
    {
        entity.HasKey(e => e.Id).HasName("fund_types__pk");

        entity.ToTable("fund_types");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("created_at");
        entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");
        entity.Property(e => e.DeletedAt)
            .HasColumnType("datetime")
            .HasColumnName("deleted_at");
        entity.Property(e => e.Name)
            .HasMaxLength(100)
            .HasColumnName("name");
        entity.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");

        entity.HasOne(d => d.CreatedByUser).WithMany(p => p.FundTypes)
            .HasForeignKey(d => d.CreatedByUserId)
            .HasConstraintName("fk_fund_types__created_by_user");
    }
}
