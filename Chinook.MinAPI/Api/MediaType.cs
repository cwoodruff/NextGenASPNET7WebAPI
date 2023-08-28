using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;

namespace Chinook.MinAPI.Api;

public static class MediaType
{
    public static void RegisterApis(WebApplication app)
    {
        app.MapGet("/MediaType", async (IChinookSupervisor db) => await db.GetAllMediaType(1, 30));

        app.MapGet("/MediaType/{id}", async (int? id, IChinookSupervisor db) => await db.GetMediaTypeById(id));
        
        app.MapPost("/MediaType/", async (MediaTypeApiModel mediaType, IChinookSupervisor db) => await db.AddMediaType(mediaType));
        
        app.MapPut("/MediaType/", async (MediaTypeApiModel mediaType, IChinookSupervisor db) => await db.UpdateMediaType(mediaType));
        
        app.MapDelete("/MediaType/{id}", async (int id, IChinookSupervisor db) => await db.DeleteMediaType(id));
    }
}