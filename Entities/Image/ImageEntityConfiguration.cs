using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZingGameApi.Entities.Image;

public class ImageEntityConfiguration: IEntityTypeConfiguration<ImageEntity>
{
    public void Configure(EntityTypeBuilder<ImageEntity> builder)
    {
        builder.Property(image => image.Url).IsRequired();
        builder.Property(image => image.Key).IsRequired();
    }
}