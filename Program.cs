
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelotConfigurations(builder.Configuration);

var app = builder.Build();
app.UseOcelot().Wait();
app.MapGet("/", () => "Ocelot esta funcionando");
app.Run();