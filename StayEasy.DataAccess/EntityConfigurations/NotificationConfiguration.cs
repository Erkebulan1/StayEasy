using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.EntityConfigurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notifications>
{
    public void Configure(EntityTypeBuilder<Notifications> builder)
    {
        // Type
        builder.Property(n => n.Type)
            .IsRequired();
            
        // Title
        builder.Property(n => n.Title)
            .IsRequired()
            .HasMaxLength(200);
            
        // Content
        builder.Property(n => n.Content)
            .IsRequired()
            .HasMaxLength(1000);
            
        // IsRead
        builder.Property(n => n.IsRead)
            .IsRequired()
            .HasDefaultValue(false);
            
        // Relationship: Notification -> User (Many-to-One)
        builder.HasOne(n => n.User)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Indexes
        builder.HasIndex(n => n.UserId);
        builder.HasIndex(n => n.Type);
        builder.HasIndex(n => n.IsRead);
        builder.HasIndex(n => n.CreatedAt);
    }
}