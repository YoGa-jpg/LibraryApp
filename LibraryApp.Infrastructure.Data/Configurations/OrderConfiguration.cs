using LibraryApp.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(o => o.OrderDate).IsRequired();
            builder
                .Property(o => o.ExpireDate).IsRequired();
            builder
                .Property(o => o.BookId).IsRequired(false);
            builder
                .Property(o => o.ReaderId).IsRequired(false);

            builder.HasData(
                new Order { Id = 1, ReaderId = 2, BookId = 2, OrderDate = new DateTime(2022, 10, 25), ExpireDate = new DateTime(2022, 11, 25) });
        }
    }
}
