using FinistSoftWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinistSoftWebApi

{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Card> Cards { get; set; } = null!;
        public DbSet<TransactionHistory> TransactionHistories { get; set; } = null!;
        public DbSet<Favourite> Favourites { get; set; } = null!;
        public DbSet<Contract> Contracts { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Card>().ToTable("Card");
            modelBuilder.Entity<TransactionHistory>().ToTable("TransactionHistory");
            modelBuilder.Entity<Favourite>().ToTable("Favourite");
            modelBuilder.Entity<Contract>().ToTable("Contract");

        }

    }
}
