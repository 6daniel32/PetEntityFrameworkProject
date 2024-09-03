using Microsoft.EntityFrameworkCore;

public class FluentApiDbContext : DbContext {
    // TODO: replicate what I have in AppDbContext but using Fluent API
    public FluentApiDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}