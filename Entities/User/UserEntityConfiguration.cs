using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZingGameApi.Entities.User;

public class UserEntityConfiguration: IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder){
        builder.Property(user => user.UserName)
            .IsRequired();
        builder.Property(user => user.Email)
            .IsRequired();
        builder.Property(user => user.PasswordHash)
            .IsRequired();
        builder.Property(user => user.PasswordSalt)
            .IsRequired();
    }
}