using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("ocelot.json")
                            .Build();
builder.Services.AddOcelot(configuration);
// Add services to the container.

var app = builder.Build();
app.UseOcelot().Wait();
app.MapGet("/", () => "Ocelot esta funcionando");
app.Run();
