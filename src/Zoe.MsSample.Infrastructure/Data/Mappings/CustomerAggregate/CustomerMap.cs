using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate;

namespace Zoe.MsSample.Infrastructure.Data.Mappings.CustomerAggregate
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .HasColumnType("uniqueidentifier")
                   .IsRequired();

            builder.OwnsOne(x => x.Name)
                   .Property(x => x.FullName)
                   .HasColumnName("FullName")
                   .HasColumnType("varchar(256)")
                   .IsRequired();

            builder.OwnsOne(x => x.Name)
                   .Property(x => x.Alias)
                   .HasColumnName("Alias")
                   .HasColumnType("varchar(20)")
                   .IsRequired();

            builder.OwnsOne(x => x.Name)
                   .Property(x => x.NormalizedFullName)
                   .HasColumnName("NormalizedFullName")
                   .HasColumnType("varchar(256)")
                   .IsRequired();

            builder.OwnsOne(x => x.Email)
                   .Property(x => x.Address)
                   .HasColumnName("Email")
                   .HasColumnType("varchar(256)")
                   .IsRequired();

            builder.OwnsOne(x => x.BirthDate)
                   .Property(x => x.Value)
                   .HasColumnName("BirthDate")
                   .HasColumnType("datetime2")
                   .IsRequired();
        }
    }
}
