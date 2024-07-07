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
        services.AddControllers().AddJsonOptions(options => {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        });
        // Custom services
        services.AddScoped<CompanyFactory>();
        services.AddScoped<TraineeFactory>();
        return services;
    }
}