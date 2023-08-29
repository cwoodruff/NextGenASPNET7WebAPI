using Chinook.FluentMinAPI.Configurations;
using FluentValidation;

namespace Chinook.FluentMinAPI.Bootstrapper;

public static class AppBuilder
{
    public static WebApplication GetApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddConnectionProvider(builder.Configuration);
        builder.Services.AddAppSettings(builder.Configuration);
        builder.Services.ConfigureRepositories();
        builder.Services.ConfigureSupervisor();
        builder.Services.ConfigureValidators();
        builder.Services.AddAPILogging();
        builder.Services.AddCORS();
        builder.Services.AddHealthChecks();
        builder.Services.AddCaching(builder.Configuration);
        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHttpClient();
        builder.Services.AddValidatorsFromAssemblyContaining<Program>();

        var app = builder.Build();
        return app;
    }
}