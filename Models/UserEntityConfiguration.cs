using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZingGameApi.Entities;

namespace ZingGameApi.Models
{
    public class UserEntityConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder){
            builder.Property(user => user.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsRequired();
            builder.Property(user => user.UserName)
                .IsRequired();
            builder.Property(user => user.Email)
                .IsRequired();
        }
    }
}