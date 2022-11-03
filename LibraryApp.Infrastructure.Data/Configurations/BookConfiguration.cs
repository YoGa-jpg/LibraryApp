using LibraryApp.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.Infrastructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(b => b.Author).HasMaxLength(40).IsRequired();
            builder
                .Property(b => b.Title).IsRequired();
            builder
                .Property(b => b.OrderId)
                .IsRequired(false);
            builder
                .HasOne(b => b.Order)
                .WithOne(o => o.Book)
                .HasForeignKey<Order>(o => o.BookId);

            builder
                .HasData(
                    new Book { Id = 1, Author = "Роберт Шекли", Title = "Секретное оружие" },
                    new Book { Id = 2, Author = "Фрэнк Герберт", Title = "Дюна", OrderId = 2 },
                    new Book { Id = 3, Author = "Рэй Брэдбери", Title = "451 градус по фаренгейту" },
                    new Book { Id = 4, Author = "Борис Стругацкий", Title = "Пикник на обочине" },
                    new Book { Id = 5, Author = "Дмитрий Глуховский", Title = "Метро 2033" });
        }
    }
}
