// src/Infrastructure/Data/Configurations/ExpenseHeaderConfiguration.cs
using ExpenseControlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControlApi.Infrastructure.Data.Configurations;

public class ExpenseHeaderConfiguration : IEntityTypeConfiguration<ExpenseHeader>
{
    public void Configure(EntityTypeBuilder<ExpenseHeader> entity)
    {
        entity.HasKey(e => e.Id).HasName("expense_headers__pk");

        entity.ToTable("expense_headers");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("created_at");
        entity.Property(e => e.Date).HasColumnName("date");
        entity.Property(e => e.DeletedAt)
            .HasColumnType("datetime")
            .HasColumnName("deleted_at");
        entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
        entity.Property(e => e.MerchantName)
            .HasMaxLength(200)
            .HasColumnName("merchant_name");
        entity.Property(e => e.MonetaryFundId).HasColumnName("monetary_fund_id");
        entity.Property(e => e.Notes)
            .HasMaxLength(1000)
            .HasColumnName("notes");
        entity.Property(e => e.OtherDocumentTypeText)
            .HasMaxLength(200)
            .HasColumnName("other_document_type_text");
        entity.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");
        entity.Property(e => e.UserId).HasColumnName("user_id");

        entity.HasOne(d => d.DocumentType).WithMany(p => p.ExpenseHeaders)
            .HasForeignKey(d => d.DocumentTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("expense_headers__document_type_id_fk");

        entity.HasOne(d => d.MonetaryFund).WithMany(p => p.ExpenseHeaders)
            .HasForeignKey(d => d.MonetaryFundId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("expense_headers__monetary_fund_id_fk");

        entity.HasOne(d => d.User).WithMany(p => p.ExpenseHeaders)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("expense_headers__user_id_fk");
    }
}


