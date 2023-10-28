namespace icarus.gateway.Extensions;
public static class Collections
{
    /*Realizado adição de configuração de ocelot para gateway*/
    public static IServiceCollection AddOcelotConfigurations(this IServiceCollection services, IConfiguration config)
    {
        
        if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development") {
            var configDev = new ConfigurationBuilder()
            .AddJsonFile("ocelot.Development.json")
            .Build();
            services.AddOcelot(configDev);
            return services;
        }

        var configuration = new ConfigurationBuilder()
        .AddJsonFile($"ocelot.json")
        .Build();
        services.AddOcelot(configuration);
        return services;
    }

    public static IServiceCollection AddJWtConfigurations(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(config["Jwt:SecretKey"]))
                };
            });
        return services;
    }
}
