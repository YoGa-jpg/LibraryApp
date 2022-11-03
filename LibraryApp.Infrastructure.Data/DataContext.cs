using LibraryApp.Domain.Core;
using LibraryApp.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Reader> Readers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new ReaderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
