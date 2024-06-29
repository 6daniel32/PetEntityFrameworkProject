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
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}