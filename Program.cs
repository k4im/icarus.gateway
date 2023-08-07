
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelotConfigurations(builder.Configuration);
builder.Services.AddHealthChecks();

var app = builder.Build();
app.UseOcelot().Wait();
app.MapGet("/", () => "Ocelot esta funcionando");
app.MapHealthChecks("/health");
app.Run();