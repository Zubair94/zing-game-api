using Microsoft.EntityFrameworkCore;
using ZingGameApi.Entities.Address;
using ZingGameApi.Entities.Base;
using ZingGameApi.Entities.Image;
using ZingGameApi.Entities.User;

namespace ZingGameApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.HasPostgresExtension("uuid-ossp");
        // builder.HasPostgresExtension("postgis");
        builder.ApplyConfiguration<BaseEntity>(new BaseEntityConfiguration());
        builder.ApplyConfiguration<UserEntity>(new UserEntityConfiguration());
        builder.ApplyConfiguration<AddressEntity>(new AddressEntityConfiguration());
        builder.ApplyConfiguration<ImageEntity>(new ImageEntityConfiguration());
    }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserEntity> Addresses { get; set; }
    public DbSet<UserEntity> Images { get; set; }
}