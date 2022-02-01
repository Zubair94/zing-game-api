using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZingGameApi.Entities.Address;

public class AddressEntityConfiguration: IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.Property(address => address.Country).IsRequired();
        builder.Property(address => address.City).IsRequired();
        builder.Property(address => address.Area).IsRequired();
        builder.Property(address => address.Street).IsRequired();
        builder.Property(address => address.PostCode).IsRequired();
        builder.Property(address => address.Phone).IsRequired();
        builder.Property(address => address.IsDefault).IsRequired();
        // builder.Property(address => address.Location).HasColumnType("geography (point)");
    }
}