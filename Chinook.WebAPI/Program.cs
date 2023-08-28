using Chinook.Domain.Helpers;
using Chinook.WebAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddConnectionProvider(builder.Configuration);
builder.Services.AddAppSettings(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureSupervisor();
builder.Services.ConfigureValidators();
builder.Services.AddAPILogging();
builder.Services.AddCORS();
builder.Services.AddHealthChecks();
builder.Services.AddCaching(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddApiExplorer();
builder.Services.AddSwaggerServices();
builder.Services.AddProblemDetail();
builder.Services.AddRepresentations();

builder.Services.AddControllers(cfg => { cfg.Filters.Add<RepresentationEnricher>(); });

var app = builder.Build();
app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseCors();
app.UseSwaggerWithVersioning();
app.MapControllers();

app.Run();

public partial class Program
{
}