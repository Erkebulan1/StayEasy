using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.EntityConfigurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        // Content
        builder.Property(m => m.Content)
            .IsRequired()
            .HasMaxLength(2000);
            
        // IsRead
        builder.Property(m => m.IsRead)
            .IsRequired()
            .HasDefaultValue(false);
            
        // Relationship: Message -> Sender (Many-to-One)
        builder.HasOne(m => m.Sender)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Relationship: Message -> Receiver (Many-to-One)
        builder.HasOne(m => m.Receiver)
            .WithMany(u => u.ReceivedMessages)
            .HasForeignKey(m => m.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Relationship: Message -> Property (Many-to-One, Optional)
        builder.HasOne(m => m.Property)
            .WithMany(p => p.Messages)
            .HasForeignKey(m => m.PropertyId)
            .OnDelete(DeleteBehavior.SetNull);
            
        // Indexes
        builder.HasIndex(m => m.SenderId);
        builder.HasIndex(m => m.ReceiverId);
        builder.HasIndex(m => m.PropertyId);
        builder.HasIndex(m => m.IsRead);
        builder.HasIndex(m => m.CreatedAt);
    }
}