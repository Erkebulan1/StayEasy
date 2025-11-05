using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.EntityConfigurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Reviews>
{
    public void Configure(EntityTypeBuilder<Reviews> builder)
    {
        // Rating
        builder.Property(r => r.Rating)
            .IsRequired();
            
        // Comment
        builder.Property(r => r.Comment)
            .IsRequired()
            .HasMaxLength(1000);
            
        // Response (Optional)
        builder.Property(r => r.Response)
            .HasMaxLength(1000);
            
        // Relationship: Review -> Property (Many-to-One)
        builder.HasOne(r => r.Property)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Relationship: Review -> User (Many-to-One)
        builder.HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Relationship: Review -> Booking (One-to-One)
        builder.HasOne(r => r.Booking)
            .WithOne(b => b.Reviews)
            .HasForeignKey<Reviews>(r => r.BookingId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Indexes
        builder.HasIndex(r => r.PropertyId);
        builder.HasIndex(r => r.UserId);
        builder.HasIndex(r => r.BookingId).IsUnique();
        builder.HasIndex(r => r.CreatedAt);
    }
}