using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.EntityConfigurations;

public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImageUrl>
{
    public void Configure(EntityTypeBuilder<PropertyImageUrl> builder)
    {
        // ImageUrl
        builder.Property(pi => pi.ImageUrl)
            .IsRequired()
            .HasMaxLength(1000);
            
        // IsMain
        builder.Property(pi => pi.IsMain)
            .IsRequired()
            .HasDefaultValue(false);
            
        // Order
        builder.Property(pi => pi.Order)
            .IsRequired();
            
        // Relationship: PropertyImage -> Property (Many-to-One)
        builder.HasOne(pi => pi.Propertys)
            .WithMany(p => p.Images)
            .HasForeignKey(pi => pi.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Indexes
        builder.HasIndex(pi => pi.PropertyId);
        builder.HasIndex(pi => pi.Order);
    }
}