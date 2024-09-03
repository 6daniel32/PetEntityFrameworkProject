using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext {
    public DbSet<Company> Companies { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}