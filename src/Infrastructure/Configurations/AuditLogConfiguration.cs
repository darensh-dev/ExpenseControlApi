// src/Infrastructure/Data/Configurations/AuditLogonfiguration.cs
using ExpenseControlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControlApi.Infrastructure.Data.Configurations;

public class AuditLogonfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> entity)
    {
        entity.HasKey(e => e.Id).HasName("audit_logs__pk");

        entity.ToTable("audit_logs");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.Action)
            .HasMaxLength(20)
            .HasColumnName("action");
        entity.Property(e => e.ChangeDate)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("change_date");
        entity.Property(e => e.ChangedByUserId).HasColumnName("changed_by_user_id");
        entity.Property(e => e.Changes).HasColumnName("changes");
        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("created_at");
        entity.Property(e => e.DeletedAt)
            .HasColumnType("datetime")
            .HasColumnName("deleted_at");
        entity.Property(e => e.RecordId).HasColumnName("record_id");
        entity.Property(e => e.TableName)
            .HasMaxLength(100)
            .HasColumnName("table_name");
        entity.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");

        entity.HasOne(d => d.ChangedByUser).WithMany(p => p.AuditLogs)
            .HasForeignKey(d => d.ChangedByUserId)
            .HasConstraintName("audit_logs__changed_by_user_id_fk");
    }
}


