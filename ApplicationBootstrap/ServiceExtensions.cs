using Microsoft.EntityFrameworkCore;

public static class ServiceExtensions {
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services, 
        IConfiguration configuration
    ) {
        // Framework and package services
        services.AddDbContext<AppDbContext>(delegate(DbContextOptionsBuilder options) {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddControllers();
        // Custom services
        services.AddScoped<ICompanyFactory, CompanyFactory>();
        return services;
    }
}