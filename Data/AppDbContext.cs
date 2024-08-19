using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext {
    // We don't need to expose the "Trainee" model
    // in the DbContext because the "Company" model already 
    // exposes it by declaring it as a property.
    public DbSet<Company> Companies { get; set; }
    // However, we will expose the "Trainee" model directly from the
    // DbContext, since this gives us the chance to access it directly
    // from the DbContext. Otherwise it would only be accessible from
    // the "Company" model.
    public DbSet<Trainee> Trainees { get; set; }
    // - Start of Many2Many Polymorphic relationship (tables declaration section)
    public DbSet<Supportable> Supportables { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<SupportCentre> SupportCentres { get; set; }
    public DbSet<SupportableSupportCentre> SupportableSupportCentres { get; set; }
    // - End of Many2Many Polymorphic relationship (tables declaration section)
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // - Start of Many2Many Polymorphic relationship (OnModelCreating)
        modelBuilder.Entity<SupportableSupportCentre>()
            .HasKey(supportableSupportCentre => new {
                supportableSupportCentre.SupportableId, 
                supportableSupportCentre.SupportCentreId 
            });

        modelBuilder.Entity<SupportableSupportCentre>()
            .HasOne(supportableSupportCentre => supportableSupportCentre.Supportable)
            .WithMany(supportable => supportable.SupportableSupportCentres)
            .HasForeignKey(supportableSupportCentre => supportableSupportCentre.SupportableId);

        modelBuilder.Entity<SupportableSupportCentre>()
            .HasOne(supportableSupportCentre => supportableSupportCentre.SupportCentre)
            .WithMany(supportCentre => supportCentre.SupportableSupportCentres)
            .HasForeignKey(supportableSupportCentre => supportableSupportCentre.SupportCentreId);
        // - End of Many2Many Polymorphic relationship (OnModelCreating)

        base.OnModelCreating(modelBuilder);
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}