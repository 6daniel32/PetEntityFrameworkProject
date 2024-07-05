public static class MiddlewarePipelineConfiguration
{
    public static WebApplication ConfigureMiddlewarePipeline(this WebApplication app)
    {
        app.UseRouting();
        app.MapControllers();

        return app;
    }
}