// src/Infrastructure/Data/Configurations/AttachmentConfiguration.cs
using ExpenseControlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControlApi.Infrastructure.Data.Configurations;

public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> entity)
    {
        entity.HasKey(e => e.Id).HasName("attachments__pk");

        entity.ToTable("attachments");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.ContentType)
            .HasMaxLength(100)
            .HasColumnName("content_type");
        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("created_at");
        entity.Property(e => e.DeletedAt)
            .HasColumnType("datetime")
            .HasColumnName("deleted_at");
        entity.Property(e => e.ExpenseHeaderId).HasColumnName("expense_header_id");
        entity.Property(e => e.FileName)
            .HasMaxLength(255)
            .HasColumnName("file_name");
        entity.Property(e => e.FileUrl)
            .HasMaxLength(1000)
            .HasColumnName("file_url");
        entity.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");

        entity.HasOne(d => d.ExpenseHeader).WithMany(p => p.Attachments)
            .HasForeignKey(d => d.ExpenseHeaderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("attachments__expense_header_id_fk");
    }
}


