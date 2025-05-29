// src/Infrastructure/Data/Configurations/UserConfiguration.cs
using ExpenseControlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControlApi.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.Property(u => u.Id).HasColumnName("ID");
        builder.Property(u => u.Username).HasColumnName("username");
        builder.Property(u => u.Password).HasColumnName("password");
        builder.Property(u => u.CreatedAt).HasColumnName("created_at");
        builder.Property(u => u.UpdatedAt).HasColumnName("updated_at");
        builder.Property(u => u.RegisterState).HasColumnName("register_state");
    }
}
