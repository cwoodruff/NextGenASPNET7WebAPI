using System;
using System.Runtime.InteropServices;
using Chinook.EFCoreData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chinook.FluentMinAPI.Configurations;

public static class ConfigureConnections
{
    public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connection = String.Empty;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            connection = configuration.GetConnectionString("ChinookDbWindows");
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            connection = configuration.GetConnectionString("ChinookDbDocker");

        services.AddDbContextPool<ChinookContext>(options => options.UseSqlServer(connection));
        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }
}