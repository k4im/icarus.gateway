var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelotConfigurations(builder.Configuration);
builder.Services.AddJWtConfigurations(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.AddCors();

var app = builder.Build();
app.UseOcelot().Wait();
app.MapGet("/", () => "Ocelot esta funcionando");
app.MapHealthChecks("/health");
app.UseCors(c =>
{
    c.AllowAnyOrigin();
    c.AllowAnyHeader();
    c.AllowAnyMethod();
});
app.Run();