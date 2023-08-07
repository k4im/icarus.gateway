namespace icarus.gateway.Extensions;

public static class AppBuilderExtensions
{
    public static IApplicationBuilder AddCorrelationMiddleware(this IApplicationBuilder appBuilder)
    {
        appBuilder.UseMiddleware<CorrelationMiddleware>();
        return appBuilder;
    }
}
