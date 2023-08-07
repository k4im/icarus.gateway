namespace icarus.gateway.Extensions;

public static class Collections
{   
    public static IServiceCollection AddOcelotConfigurations(this IServiceCollection services, IConfiguration config)
    {
        var configuration = new ConfigurationBuilder()
        .AddJsonFile($"ocelot.{config["ASPNETCORE_ENVIRONMENT"]}.json")
        .Build();
        services.AddOcelot(configuration);
        return services;
    }
        
}
