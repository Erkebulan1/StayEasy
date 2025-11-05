using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.EntityConfigurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        // StartDate
        builder.Property(b => b.StartDate)
            .IsRequired();
            
        // EndDate
        builder.Property(b => b.EndDate)
            .IsRequired();
            
        // TotalPrice
        builder.Property(b => b.TotalPrice)
            .IsRequired()
            .HasPrecision(18, 2);
            
        // Status
        builder.Property(b => b.Status)
            .IsRequired();
            
        // Message (Optional)
        builder.Property(b => b.Message)
            .HasMaxLength(1000);
            
        // Relationship: Booking -> Property (Many-to-One)
        builder.HasOne(b => b.Property)
            .WithMany(p => p.Bookings)
            .HasForeignKey(b => b.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Relationship: Booking -> User (Many-to-One)
        builder.HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Indexes
        builder.HasIndex(b => b.PropertyId);
        builder.HasIndex(b => b.UserId);
        builder.HasIndex(b => b.Status);
        builder.HasIndex(b => b.StartDate);
        builder.HasIndex(b => b.CreatedAt);
    }
}