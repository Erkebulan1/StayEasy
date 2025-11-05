using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.EntityConfigurations;

public class PropertyAmenityConfiguration : IEntityTypeConfiguration<PropertyAmenities>
{
    public void Configure(EntityTypeBuilder<PropertyAmenities> builder)
    {
        // Name
        builder.Property(pa => pa.Name)
            .IsRequired()
            .HasMaxLength(100);
            
        // Icon (Optional)
        builder.Property(pa => pa.Icon)
            .HasMaxLength(50);
            
        // Relationship: PropertyAmenity -> Property (Many-to-One)
        builder.HasOne(pa => pa.Propertys)
            .WithMany(p => p.Amenities)
            .HasForeignKey(pa => pa.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Indexes
        builder.HasIndex(pa => pa.PropertyId);
    }
}