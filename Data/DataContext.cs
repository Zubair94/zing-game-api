using Microsoft.EntityFrameworkCore;
using ZingGameApi.Entities.User;

namespace ZingGameApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.HasPostgresExtension("uuid-ossp");
            builder.ApplyConfiguration<User>(new UserEntityConfiguration());
        }
        public DbSet<User> Users { get; set; }
    }
}