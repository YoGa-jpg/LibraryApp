using LibraryApp.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.Infrastructure.Data.Configurations
{
    public class ReaderConfiguration : IEntityTypeConfiguration<Reader>
    {
        public void Configure(EntityTypeBuilder<Reader> builder)
        {
            builder
                .HasMany(r => r.Orders)
                .WithOne(o => o.Reader)
                .HasForeignKey(o => o.ReaderId);
            builder
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(r => r.Firstname).HasMaxLength(20).IsRequired();
            builder
                .Property(r => r.Lastname).HasMaxLength(20).IsRequired();

            builder
                .HasData(
                    new Reader { Id = 1, Firstname = "Антон", Lastname = "Давидович" },
                    new Reader { Id = 2, Firstname = "Филипп", Lastname = "Приходько" },
                    new Reader { Id = 3, Firstname = "Вахид", Lastname = "Уходько" });
        }
    }
}
