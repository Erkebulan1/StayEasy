using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // FirstName
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        // LastName
        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(100);

        // Email (Unique)
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(u => u.Email)
            .IsUnique();

        // PasswordHash
        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(500);

        // PhoneNumber (Optional)
        builder.Property(u => u.PhoneNumber)
            .HasMaxLength(20);

        // Role
        builder.Property(u => u.Role)
            .IsRequired();

        // IsEmailConfirmed
        builder.Property(u => u.IsEmailConfirmed)
            .IsRequired()
            .HasDefaultValue(false);

        // ProfileImageUrl (Optional)
        builder.Property(u => u.ProfileImageUrl)
            .HasMaxLength(500);

        // Indexes
        builder.HasIndex(u => u.Email);
        builder.HasIndex(u => u.PhoneNumber);
        builder.HasIndex(u => u.Role);
    }
}
