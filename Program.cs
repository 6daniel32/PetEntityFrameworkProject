using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/testdb", async (AppDbContext db) =>
{
    try
    {
        await db.Database.OpenConnectionAsync();
        db.Database.CloseConnection();
        return "Successfully connected to the database.";
    }
    catch (Exception e)
    {
        return $"An error occurred: {e.Message}";
    }
});

app.Run();
