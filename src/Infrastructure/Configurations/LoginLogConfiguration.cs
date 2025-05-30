// src/Infrastructure/Data/Configurations/LoginLogConfiguration.cs
using ExpenseControlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControlApi.Infrastructure.Data.Configurations;

public class LoginLogConfiguration : IEntityTypeConfiguration<LoginLog>
{
    public void Configure(EntityTypeBuilder<LoginLog> entity)
    {
        entity.HasKey(e => e.Id).HasName("login_log__pk");

        entity.ToTable("login_log");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("created_at");
        entity.Property(e => e.Ip)
            .HasMaxLength(30)
            .IsUnicode(false)
            .HasColumnName("ip");
        entity.Property(e => e.Token)
            .HasColumnType("text")
            .HasColumnName("token");
        entity.Property(e => e.UserId).HasColumnName("user_id");
    }
}


