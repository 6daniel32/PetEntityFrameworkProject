using Microsoft.EntityFrameworkCore;

public class FluentApiDbContext : DbContext {
    public DbSet<CompanyFluent> FluentCompanies { get; set; }
    public DbSet<TraineeFluent> FluentTrainees { get; set; }
    public DbSet<TestFluent> FluentTests { get; set; }
    public DbSet<AddressFluent> FluentAddresses { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CompanyEntityTypeConfiguration().Configure(modelBuilder.Entity<CompanyFluent>());
        new TraineeEntityTypeConfiguration().Configure(modelBuilder.Entity<TraineeFluent>());
        new TestEntityTypeConfiguration().Configure(modelBuilder.Entity<TestFluent>());
        new AddressEntityTypeConfiguration().Configure(modelBuilder.Entity<AddressFluent>());
        base.OnModelCreating(modelBuilder);
    }
    public FluentApiDbContext(DbContextOptions<FluentApiDbContext> options) : base(options) {}
}