using LibraryApp.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Reader> Readers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reader>()
                .HasMany(r => r.Orders)
                .WithOne(o => o.Reader)
                .HasForeignKey(o => o.ReaderId);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Order)
                .WithOne(o => o.Book)
                .HasForeignKey<Order>(o => o.BookId);

            modelBuilder.Entity<Reader>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Reader>()
                .Property(r => r.Firstname).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Reader>()
                .Property(r => r.Lastname).HasMaxLength(20).IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>()
                .Property(b => b.Author).HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Book>()
                .Property(b => b.Title).IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate).IsRequired();
            modelBuilder.Entity<Order>()
                .Property(o => o.ExpireDate).IsRequired();

            modelBuilder.Entity<Reader>().HasData(
                new Reader { Id = 1, Firstname = "Антон", Lastname = "Давидович" },
                new Reader { Id = 2, Firstname = "Филипп", Lastname = "Приходько"},
                new Reader { Id = 3, Firstname = "Вахид", Lastname = "Уходько" });
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Author = "Роберт Шекли", Title = "Секретное оружие" },
                new Book { Id = 2, Author = "Фрэнк Герберт", Title = "Дюна", OrderId = 2},
                new Book { Id = 3, Author = "Рэй Брэдбери", Title = "451 градус по фаренгейту" },
                new Book { Id = 4, Author = "Борис Стругацкий", Title = "Пикник на обочине" },
                new Book { Id = 5, Author = "Дмитрий Глуховский", Title = "Метро 2033" });
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, ReaderId = 2, BookId = 2, OrderDate = new DateTime(2022, 10, 25), ExpireDate = new DateTime(2022, 11, 25) });
        }
    }
}
