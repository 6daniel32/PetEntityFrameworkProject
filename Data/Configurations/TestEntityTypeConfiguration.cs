using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TestEntityTypeConfiguration : IEntityTypeConfiguration<TestFluent>
{
    public void Configure(EntityTypeBuilder<TestFluent> builder)
    {
        // Configure primary key
        builder.HasKey(t => t.TestId);

        // Configure Title property
        builder
            .Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(50);

        // Configure many-to-many relationship with Test
        builder
            .HasMany(t => t.Trainees)
            .WithMany(tr => tr.Tests)
            // Configuring the pivot table is optional, but recommended
            .UsingEntity<Dictionary<string, object>>(
                "TraineeTest",
                j => j
                    .HasOne<TraineeFluent>()
                    .WithMany()
                    .HasForeignKey("TraineeId"),
                j => j
                    .HasOne<TestFluent>()
                    .WithMany()
                    .HasForeignKey("TestId")
            );
    }
}