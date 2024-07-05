using Microsoft.EntityFrameworkCore;

public static class ServiceExtensions {
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services, 
        IConfiguration configuration
    ) {
        services.AddDbContext<AppDbContext>(delegate(DbContextOptionsBuilder options) {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddControllers();
        return services;
    }
}