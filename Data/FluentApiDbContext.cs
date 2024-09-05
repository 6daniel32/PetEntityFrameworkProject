using Microsoft.EntityFrameworkCore;

public class FluentApiDbContext : DbContext {
    public DbSet<CompanyFluent> Companies { get; set; }
    public DbSet<TraineeFluent> Trainees { get; set; }
    public DbSet<TestFluent> Tests { get; set; }
    public DbSet<AddressFluent> Addresses { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CompanyEntityTypeConfiguration().Configure(modelBuilder.Entity<CompanyFluent>());
        new TraineeEntityTypeConfiguration().Configure(modelBuilder.Entity<TraineeFluent>());
        new TestEntityTypeConfiguration().Configure(modelBuilder.Entity<TestFluent>());
        new AddressEntityTypeConfiguration().Configure(modelBuilder.Entity<AddressFluent>());
        base.OnModelCreating(modelBuilder);
    }
    public FluentApiDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}