using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile($"ocelot.{builder.Configuration["ASPNETCORE_ENVIRONMENT"]}.json")
                            .Build();
builder.Services.AddOcelot(configuration);

var app = builder.Build();
app.UseOcelot().Wait();
app.MapGet("/", () => "Ocelot esta funcionando");
app.Run();
