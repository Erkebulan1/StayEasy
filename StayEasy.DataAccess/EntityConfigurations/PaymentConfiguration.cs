using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.EntityConfigurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payments>
{
    public void Configure(EntityTypeBuilder<Payments> builder)
    {
        // Amount
        builder.Property(p => p.Amount)
            .IsRequired()
            .HasPrecision(18, 2);
            
        // Currency
        builder.Property(p => p.Currency)
            .IsRequired()
            .HasMaxLength(10);
            
        // Status
        builder.Property(p => p.PaymentStatus)
            .IsRequired();
            
        // PaymentMethod
        builder.Property(p => p.PaymentMethod)
            .IsRequired()
            .HasMaxLength(50);
            
        // TransactionId (Optional)
        builder.Property(p => p.TransactionId)
            .HasMaxLength(200);
            
        // Relationship: Payment -> User (Many-to-One)
        builder.HasOne(p => p.User)
            .WithMany(u => u.Payments)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Relationship: Payment -> Booking (Many-to-One, Optional)
        builder.HasOne(p => p.Booking)
            .WithMany(b => b.Payments)
            .HasForeignKey(p => p.BookingId)
            .OnDelete(DeleteBehavior.SetNull);
            
        // Indexes
        builder.HasIndex(p => p.UserId);
        builder.HasIndex(p => p.BookingId);
        builder.HasIndex(p => p.PaymentStatus);
        builder.HasIndex(p => p.TransactionId).IsUnique();
        builder.HasIndex(p => p.CreatedAt);
    }
}

