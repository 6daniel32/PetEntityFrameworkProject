using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CompanyEntityTypeConfiguration : IEntityTypeConfiguration<CompanyFluent>
{
    public void Configure(EntityTypeBuilder<CompanyFluent> builder)
    {
        // Specify table name
        builder.ToTable("FluentCompanies");

        // Configure primary key
        builder.HasKey(c => c.CompanyId);

        // Configure Name property
        builder
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

        // Configure one-to-many (has many) relationship with Trainee
        builder
            .HasMany(c => c.Trainees)
            .WithOne(t => t.Company);

        // Configure one-to-one relationship with Address
        builder
            .HasOne(c => c.Address)
            .WithOne(a => a.Company);
    }
}