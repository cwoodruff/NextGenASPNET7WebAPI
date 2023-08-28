using Chinook.Domain.ApiModels;
using Chinook.Domain.Repositories;
using Chinook.Domain.Supervisor;
using Chinook.Domain.Validation;
using Chinook.EFCoreData.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.HttpLogging;

namespace Chinook.MinAPI.Configurations;

public static class ServicesConfiguration
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAlbumRepository, AlbumRepository>()
            .AddScoped<IArtistRepository, ArtistRepository>()
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IEmployeeRepository, EmployeeRepository>()
            .AddScoped<IGenreRepository, GenreRepository>()
            .AddScoped<IInvoiceRepository, InvoiceRepository>()
            .AddScoped<IInvoiceLineRepository, InvoiceLineRepository>()
            .AddScoped<IMediaTypeRepository, MediaTypeRepository>()
            .AddScoped<IPlaylistRepository, PlaylistRepository>()
            .AddScoped<ITrackRepository, TrackRepository>();
    }

    public static void ConfigureSupervisor(this IServiceCollection services)
    {
        services.AddScoped<IChinookSupervisor, ChinookSupervisor>();
    }

    public static void AddAPILogging(this IServiceCollection services)
    {
        services.AddLogging(builder => builder
            .AddConsole()
            .AddFilter(level => level >= LogLevel.Information)
        );

        services.AddHttpLogging(logging =>
        {
            // Customize HTTP logging.
            logging.LoggingFields = HttpLoggingFields.All;
            logging.RequestHeaders.Add("My-Request-Header");
            logging.ResponseHeaders.Add("My-Response-Header");
            logging.MediaTypeOptions.AddText("application/javascript");
            logging.RequestBodyLogLimit = 4096;
            logging.ResponseBodyLogLimit = 4096;
        });
    }

    public static void ConfigureValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation()
            .AddScoped<IValidator<AlbumApiModel>, AlbumValidator>()
            .AddScoped<IValidator<ArtistApiModel>, ArtistValidator>()
            .AddScoped<IValidator<CustomerApiModel>, CustomerValidator>()
            .AddScoped<IValidator<EmployeeApiModel>, EmployeeValidator>()
            .AddScoped<IValidator<GenreApiModel>, GenreValidator>()
            .AddScoped<IValidator<InvoiceApiModel>, InvoiceValidator>()
            .AddScoped<IValidator<InvoiceLineApiModel>, InvoiceLineValidator>()
            .AddScoped<IValidator<MediaTypeApiModel>, MediaTypeValidator>()
            .AddScoped<IValidator<PlaylistApiModel>, PlaylistValidator>()
            .AddScoped<IValidator<TrackApiModel>, TrackValidator>();
    }

    public static void AddCORS(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }

    public static void AddCaching(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddResponseCaching();
        services.AddMemoryCache();
    }
}