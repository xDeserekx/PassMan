using Microsoft.EntityFrameworkCore;
using PassMan.Models;

namespace EntityFramework
{
    public class AccountDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }
        public AccountDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetTransaction>().OwnsOne(x => x.Stock);

            base.OnModelCreating(modelBuilder);
        }
    }
}
