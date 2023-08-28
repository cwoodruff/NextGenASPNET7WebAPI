using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Api;

public static class MediaType
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/MediaType",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllMediaType(page, pageSize)).WithName("GetMediaTypes")
            .WithOpenApi();

        app.MapGet("/MediaType/{id}", async (int? id, IChinookSupervisor db) => await db.GetMediaTypeById(id)).WithName("GetMediaType")
            .WithOpenApi();

        app.MapPost("/MediaType/",
            async ([FromBody] MediaTypeApiModel mediaType, IChinookSupervisor db) => await db.AddMediaType(mediaType)).WithName("AddMediaType")
            .WithOpenApi();

        app.MapPut("/MediaType/",
            async ([FromBody] MediaTypeApiModel mediaType, IChinookSupervisor db) =>
            await db.UpdateMediaType(mediaType)).WithName("UpdateMediaType")
            .WithOpenApi();

        app.MapDelete("/MediaType/{id}", async (int id, IChinookSupervisor db) => await db.DeleteMediaType(id)).WithName("DeletemediaType")
            .WithOpenApi();
    }
}