using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TraineeEntityTypeConfiguration : IEntityTypeConfiguration<TraineeFluent>
{
    public void Configure(EntityTypeBuilder<TraineeFluent> builder)
    {
        // Configure primary key
        builder.HasKey(t => t.TraineeId);

        // Configure Name property
        builder
            .Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(50);

        // Configure one-to-many (belongs to) relationship with Company
        builder
            .HasOne(t => t.Company)
            .WithMany(c => c.Trainees)
            .HasForeignKey(t => t.CompanyId);

        // Configure many-to-many relationship with Test
        builder
            .HasMany(t => t.Tests)
            .WithMany(tr => tr.Trainees)
            // Configuring the pivot table is optional, but recommended
            .UsingEntity<Dictionary<string,object>>(
                "TraineeTest",
                j => j
                    .HasOne<TestFluent>()
                    .WithMany()
                    .HasForeignKey("TestId"),
                j => j
                    .HasOne<TraineeFluent>()
                    .WithMany()
                    .HasForeignKey("TraineeId")
            );
    }
}