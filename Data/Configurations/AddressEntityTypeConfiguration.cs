using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<AddressFluent>
{
    public void Configure(EntityTypeBuilder<AddressFluent> builder)
    {
        // Specify table name
        builder.ToTable("FluentAddresses");

        // Configure primary key
        builder.HasKey(t => t.AddressId);

        // Configure properties
        builder
            .Property(t => t.Street)
            .IsRequired()
            .HasMaxLength(50);
        builder
            .Property(t => t.City)
            .IsRequired()
            .HasMaxLength(50);
        builder
            .Property(t => t.State)
            .IsRequired()
            .HasMaxLength(50);
        builder
            .Property(t => t.Country)
            .IsRequired()
            .HasMaxLength(50);

        // Configure one-to-one relationship with Company
        builder
            .HasOne(a => a.Company)
            .WithOne(c => c.Address)
            .HasForeignKey<AddressFluent>(a => a.CompanyId);
    }
}